using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Extensions.FileSystemGlobbing;
using Microsoft.Extensions.FileSystemGlobbing.Abstractions;
using ProjectCleaner.Util;

//ref : https://www.goatly.net/post/file-globbing-in-dotnet/
//ref:  https://stackoverflow.com/questions/41337607/prepending-doesnt-work-for-handling-long-paths

namespace ucoruh
{
    public partial class MainFrm : Form
    {

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool DeleteFile(string path);

        #region VARIABLES

        /// <summary>
        /// TOPTAL gitignore generator portal url
        /// </summary>
        public const string toptalurl = @"https://www.toptal.com/developers/gitignore";

        /// <summary>
        /// The folder cleaner thread
        /// </summary>
        private Thread _cleanerThread;

        private int _doxygenFileCount = 0;
        private int _ignoredFileCount = 0;
        private int _totalFileCount = 0;
        private int _currentFileIndex = 0;

        private DateTime _startedTime = DateTime.MinValue;
        private DateTime _finishedTime = DateTime.MinValue;
        private TimeSpan _operationDuration = TimeSpan.Zero;

        #endregion

        #region FUNCTIONS

        /// <summary>
        /// Recursively removes empty directories for specific root directory
        /// </summary>
        /// <param name="rootDir">Root directory for empty folders</param>
        private void removeEmptyDirectories(string rootDir)
        {
            foreach (var directory in Directory.GetDirectories(rootDir))
            {
                removeEmptyDirectories(directory);

                if (Directory.GetFiles(directory).Length == 0 && Directory.GetDirectories(directory).Length == 0)
                {

                    try
                    {
                        GuiUtility.LogTextEvent(txtLog, Color.Red, "Deleting Empty Folder -> " + directory);

                        Directory.Delete(directory, true);

                    }
                    catch (Exception ex)
                    {
                        GuiUtility.LogTextEvent(txtLog, Color.Purple, "Deleting Empty Folder Error -> " + ex.ToString());
                    }
                }
            }
        }

        private void updateProgressbar(double index,double count)
        {
            toolProgressBar.Maximum = (int)count;
            
            if(index<count)
            {
                toolProgressBar.Value = (int)index;
            }
            else
            {
                toolProgressBar.Value = (int)count;
            }

            toolProgressBar.Step = 1;

            double percentage = (double)(index / count) * 100L;

            if (statusStripMain.InvokeRequired)
            {
                statusStripMain.Invoke(new MethodInvoker(delegate
                {
                    toolPercentage.Text = "%" + percentage.ToString("F2");
                    statusStripMain.Refresh();
                }));
            }
            else
            {
                toolPercentage.Text = "%" + percentage;
                statusStripMain.Refresh();
            }

        }

        /// <summary>
        /// Cleaner Thread Function
        /// Clean project folders according to given .gitignore file
        /// Also cleans doxygen outputs from doxygen configurations
        /// </summary>
        private void cleanFolders()
        {

            _startedTime = DateTime.Now;

            toolStartedTime.Text = "Started: [" + _startedTime.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss")+"]";
            toolFinished.Text = "Finished: " + "[--:--:--]";
            

            GuiUtility.UpdateControlEnabled(listboxSearchFolders, false);

            GuiUtility.UpdateControlEnabled(btnAdd, false);
            GuiUtility.UpdateControlEnabled(btnCleanForm, false);
            GuiUtility.UpdateControlEnabled(btnMoveUp, false);
            GuiUtility.UpdateControlEnabled(btnMoveDown, false);
            GuiUtility.UpdateControlEnabled(btnRemove, false);

            GuiUtility.UpdateControlEnabled(btnRunCleaner, false);

            GuiUtility.UpdateControlEnabled(btnSelectGitIgnore, false);
            GuiUtility.UpdateControlEnabled(btnStopCleaner, true);


            GuiUtility.LogTextEvent(txtLog, Color.Blue, "Cleaning Started...");

            string[] folders = new string[listboxSearchFolders.Items.Count];

            listboxSearchFolders.Items.CopyTo(folders, 0);

            try
            {

                #region COUNT OPERATIONS
                if (chkDoxygenOutputDeletion.Checked)
                {
                    foreach (string folder in folders)
                    {
                        var doxygenFiles = Directory.GetFiles(folder, "*", SearchOption.AllDirectories).Where(s => s.EndsWith("Doxyfile"));
                        _doxygenFileCount+= doxygenFiles.Count();
                    }
                }

                string[] gitignoreLinesForCounting = File.ReadAllLines(txtGitignorePath.Text);
                List<string> gitIgnoreGlobsForCounting = new List<string>();

                for (int i = 0; i < gitignoreLinesForCounting.Length; i++)
                {

                    if (!gitignoreLinesForCounting[i].StartsWith("#") && !String.IsNullOrEmpty(gitignoreLinesForCounting[i]) && !String.IsNullOrWhiteSpace(gitignoreLinesForCounting[i]))
                    {
                        gitignoreLinesForCounting[i] = "**/" + gitignoreLinesForCounting[i];

                        gitIgnoreGlobsForCounting.Add(gitignoreLinesForCounting[i]);
                    }
                }

                // Create and configure the FileSystemGlobbing Matcher using the ignore globs
                var matcherForCounting = new Matcher();
                //matcher.AddInclude("**/*");
                //matcher.AddExcludePatterns(gitIgnoreGlobs);
                //matcher.AddInclude("**/*");
                matcherForCounting.AddIncludePatterns(gitIgnoreGlobsForCounting);

                foreach (string folder in folders)
                {
                    var dirInfo = new DirectoryInfo(folder);

                    // Execute the matcher against the directory
                    var result = matcherForCounting.Execute(new DirectoryInfoWrapper(dirInfo));

                    _ignoredFileCount += result.Files.Count();
                }


                _totalFileCount = _ignoredFileCount + _doxygenFileCount;
                
                
                #endregion


                 #region DELETE DOXYGEN OUTPUTS
                 if (chkDoxygenOutputDeletion.Checked)
                {
                    foreach (string folder in folders)
                    {

                        var doxygenFiles = Directory.GetFiles(folder, "*", SearchOption.AllDirectories).Where(s => s.EndsWith("Doxyfile"));

                        foreach (string doxygenFile in doxygenFiles)
                        {
                            _currentFileIndex++;
                            updateProgressbar(_currentFileIndex, _totalFileCount);

                            try
                            {
                                //read configuration and find directory
                                string[] doxyFileLines = File.ReadAllLines(doxygenFile);

                                foreach (string doxygenFileLine in doxyFileLines)
                                {
                                    if (doxygenFileLine.StartsWith("OUTPUT_DIRECTORY"))
                                    {
                                        string[] tokens = doxygenFileLine.Split('=');
                                        if (tokens.Length > 1)
                                        {
                                            string parentPath = Directory.GetParent(doxygenFile).FullName;
                                            string doxygenOutputFolder = Path.Combine(parentPath, tokens[1].TrimStart().TrimEnd());

                                            if (Directory.Exists(doxygenOutputFolder))
                                            {
                                                FileAttributes attr = File.GetAttributes(doxygenOutputFolder);
                                                if ((attr & FileAttributes.Directory) != FileAttributes.Directory)
                                                    continue;

                                                try
                                                {

                                                    GuiUtility.LogTextEvent(txtLog, Color.Red, "Deleting Doxygen Folder -> " + doxygenOutputFolder);

                                                    //ZetaLongPaths.ZlpSafeFileOperations.SafeDeleteDirectory(doxygenOutputFolder);
                                                    Directory.Delete(doxygenOutputFolder, true);

                                                }
                                                catch (Exception ex)
                                                {
                                                    GuiUtility.LogTextEvent(txtLog, Color.Purple, "Deleting Doxygen Folder Error -> " + ex.ToString());

                                                }

                                            }
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                GuiUtility.LogTextEvent(txtLog, Color.Purple, "Deleting Doxygen Folder Error -> " + ex.ToString());
                            }
                        }

                    }
                }
                #endregion

                #region REMOVE GITIGNORE FILES

                string[] gitignoreLines = File.ReadAllLines(txtGitignorePath.Text);
                List<string> gitIgnoreGlobs = new List<string>();

                for (int i = 0; i < gitignoreLines.Length; i++)
                {

                    if (!gitignoreLines[i].StartsWith("#") && !String.IsNullOrEmpty(gitignoreLines[i]) && !String.IsNullOrWhiteSpace(gitignoreLines[i]))
                    {
                        gitignoreLines[i] = "**/" + gitignoreLines[i];

                        gitIgnoreGlobs.Add(gitignoreLines[i]);
                    }
                }

                // Create and configure the FileSystemGlobbing Matcher using the ignore globs
                var matcher = new Matcher();
                //matcher.AddInclude("**/*");
                //matcher.AddExcludePatterns(gitIgnoreGlobs);
                //matcher.AddInclude("**/*");
                matcher.AddIncludePatterns(gitIgnoreGlobs);

                foreach (string folder in folders)
                {

                    Directory.SetCurrentDirectory(folder);

                    GuiUtility.LogTextEvent(txtLog, Color.Blue, "Current Directory: " + folder);

                    var dirInfo = new DirectoryInfo(folder);

                    // Execute the matcher against the directory
                    var result = matcher.Execute(new DirectoryInfoWrapper(dirInfo));

                    GuiUtility.LogTextEvent(txtLog, Color.Blue, "Has Matched: " + result.HasMatches);

                    foreach (var file in result.Files)
                    {

                        _currentFileIndex++;
                        updateProgressbar(_currentFileIndex, _totalFileCount);

                        string fileFullPath = Path.Combine(folder, file.Path.Replace('/','\\'));

                        GuiUtility.LogTextEvent(txtLog, Color.Blue, "Found File/Dir: " + fileFullPath);

                        try
                        {
                            GuiUtility.LogTextEvent(txtLog, Color.Red, "Deleting Ignored File -> " + fileFullPath);

                            DeleteFile(fileFullPath);
                        }
                        catch (Exception ex)
                        {
                            GuiUtility.LogTextEvent(txtLog, Color.Purple, "Deleting Ignored File Error -> " + ex.ToString());
                        }
                    }


                    removeEmptyDirectories(folder);
                }

                #endregion

            }
            catch (UnauthorizedAccessException uaexc)
            {
                GuiUtility.LogTextEvent(txtLog, Color.Purple, "Deleting Ignored Folder Error -> " + uaexc.ToString());
            }
            catch (System.IO.IOException ioexc)
            {
                GuiUtility.LogTextEvent(txtLog, Color.Purple, "Deleting Ignored Folder Error -> " + ioexc.ToString());
            }

            GuiUtility.LogTextEvent(txtLog, Color.OrangeRed, "---- COMPLETED ----");


            GuiUtility.UpdateControlEnabled(listboxSearchFolders, true);
            GuiUtility.UpdateControlEnabled(btnSelectGitIgnore, true);


            configureControlEnability();

            timerDurationUpdater.Stop();

            _finishedTime = DateTime.Now;

            toolFinished.Text = "Finished: [" + _finishedTime.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss")+"]";

        }

        /// <summary>
        /// Enable and Disable Controls for Special Cases
        /// </summary>
        private void configureControlEnability()
        {
            GuiUtility.UpdateControlEnabled(btnCleanForm, true);

            if (listboxSearchFolders.Items.Count == 0)
            {
                GuiUtility.UpdateControlEnabled(btnMoveUp, false);
                GuiUtility.UpdateControlEnabled(btnMoveDown, false);
                GuiUtility.UpdateControlEnabled(btnRemove, false);
                GuiUtility.UpdateControlEnabled(btnAdd, true);
                GuiUtility.UpdateControlEnabled(btnRunCleaner, false);
                GuiUtility.UpdateControlEnabled(btnStopCleaner, false);

                return;
            }
            else
            {

                GuiUtility.UpdateControlEnabled(btnMoveUp, true);
                GuiUtility.UpdateControlEnabled(btnMoveDown, true);
                GuiUtility.UpdateControlEnabled(btnRemove, true);
                GuiUtility.UpdateControlEnabled(btnAdd, true);

                if (!String.IsNullOrEmpty(txtGitignorePath.Text))
                {
                    GuiUtility.UpdateControlEnabled(btnRunCleaner, true);
                    GuiUtility.UpdateControlEnabled(btnStopCleaner, false);
                }
                else
                {
                    GuiUtility.UpdateControlEnabled(btnRunCleaner, false);
                    GuiUtility.UpdateControlEnabled(btnStopCleaner, false);
                }
            }

        }

        #endregion

        public MainFrm()
        {
            InitializeComponent();

            // Allow thread interaction with UI
            MainFrm.CheckForIllegalCrossThreadCalls = false;
        }


        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            if (listboxSearchFolders.SelectedIndex >= 1)
            {
                int index = listboxSearchFolders.SelectedIndex;
                string s = (string)listboxSearchFolders.SelectedItem;
                listboxSearchFolders.Items.RemoveAt(index);
                listboxSearchFolders.Items.Insert(index - 1, s);
                listboxSearchFolders.SelectedIndex = index - 1;
            }
        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            if (listboxSearchFolders.SelectedIndex != -1 &&
                listboxSearchFolders.SelectedIndex != listboxSearchFolders.Items.Count - 1)
            {
                int index = listboxSearchFolders.SelectedIndex;
                string s = (string)listboxSearchFolders.SelectedItem;
                listboxSearchFolders.Items.RemoveAt(index);
                listboxSearchFolders.Items.Insert(index + 1, s);
                listboxSearchFolders.SelectedIndex = index + 1;
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (listboxSearchFolders.SelectedIndex != -1)
            {
                int index = listboxSearchFolders.SelectedIndex;

                listboxSearchFolders.Items.RemoveAt(index);

                if (index == listboxSearchFolders.Items.Count)
                {
                    index--;
                }

                if (index >= 0)
                {
                    listboxSearchFolders.SelectedIndex = index;
                }
            }

            configureControlEnability();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    listboxSearchFolders.Items.Add(fbd.SelectedPath);
                }
            }

            configureControlEnability();

        }

        private void btnSelectGitIgnore_Click(object sender, EventArgs e)
        {
            OpenFileDialog d = new OpenFileDialog();
            d.Multiselect = false;
            d.Filter = "Git Ignore|*.gitignore";
            DialogResult dr = d.ShowDialog(this);

            if (dr != DialogResult.Cancel && d.FileNames.Length > 0)
            {

                txtGitignorePath.Text = d.FileName;

                btnMoveUp.Enabled = true;
                btnMoveDown.Enabled = true;
                btnRemove.Enabled = true;

                if (listboxSearchFolders.Items.Count > 1)
                {
                    btnRunCleaner.Enabled = true;
                }
            }

            configureControlEnability();
        }

        public static void DeleteDirectory(string target_dir)
        {
            string[] files = Directory.GetFiles(target_dir);
            string[] dirs = Directory.GetDirectories(target_dir);

            foreach (string file in files)
            {
                File.SetAttributes(file, FileAttributes.Normal);
                File.Delete(file);
            }

            foreach (string dir in dirs)
            {
                DeleteDirectory(dir);
            }

            Directory.Delete(target_dir, false);
        }


        private void btnCleanProjects_Click(object sender, EventArgs e)
        {
            try
            {

                _ignoredFileCount = 0;
                _doxygenFileCount = 0;
                _totalFileCount = 0;
                _currentFileIndex = 0;

                toolProgressBar.Maximum = 100;
                toolProgressBar.Step = 1;
                toolProgressBar.Value = 0;

                if (_cleanerThread != null)
                {
                    if (_cleanerThread.IsAlive)
                        _cleanerThread.Abort();
                }
                _cleanerThread = new Thread(() => cleanFolders());
                _cleanerThread.Start();

                timerDurationUpdater.Start();

            }
            catch (Exception ex)
            {
               GuiUtility.LogTextEvent(txtLog, Color.Red, "RunCleanFunctionThread Error -> " + ex.Message);
            }
        }

        private void listboxSearchFolders_DragEnter(object sender, DragEventArgs e)
        {

            if (!listboxSearchFolders.Enabled)
                return;

            // Only accept dropped files, not text etc
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void listboxSearchFolders_DragDrop(object sender, DragEventArgs e)
        {

            if (!listboxSearchFolders.Enabled)
                return;

            string[] folders = (string[])e.Data.GetData(DataFormats.FileDrop);

            bool allDirectory = true;
            // Make sure only dropped item is directory
            foreach (string s in folders)
            {
                // get the file attributes for file or directory
                FileAttributes attr = File.GetAttributes(s);

                //detect whether its a directory or file
                if ((attr & FileAttributes.Directory) != FileAttributes.Directory)
                {
                    allDirectory = false;
                    break;
                }

            }

            if (!allDirectory)
            {
                MessageBox.Show("Please drag and drop directory only",
                                "File Detected, Required Directory",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;

            }

            if (allDirectory && folders.Length > 0)
            {
                listboxSearchFolders.Items.AddRange(folders);
            }

            configureControlEnability();

        }

        private void txtGitignorePath_DragEnter(object sender, DragEventArgs e)
        {

            if (!btnSelectGitIgnore.Enabled)
                return;

            // Only accept dropped files, not text etc
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void txtGitignorePath_DragDrop(object sender, DragEventArgs e)
        {
            if (!btnSelectGitIgnore.Enabled)
                return;

            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            bool fileCorrect = true;
            // Make sure only PDFs are dropped
            foreach (string s in files)
            {

                if (!s.ToLower().EndsWith(".gitignore"))
                {
                    fileCorrect = false;
                    break;
                }

            }

            if (!fileCorrect)
            {
                MessageBox.Show("Please drag and drop gitignore file only",
                                "Wrong File Detected",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;

            }

            if (fileCorrect && files.Length > 0)
            {
                txtGitignorePath.Text = files[0];
            }

            configureControlEnability();
        }

        private void btnStopCleaning_Click(object sender, EventArgs e)
        {
            _cleanerThread.Abort();

            GuiUtility.LogTextEvent(txtLog, Color.Blue, "Cleaning Stopped...");

            configureControlEnability();

            timerDurationUpdater.Stop();

            _finishedTime = DateTime.Now;

            toolFinished.Text = "Finished:" + _finishedTime.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss");

        }



        private void btnOpenToptal_Click(object sender, EventArgs e)
        {
            Process.Start(toptalurl);
        }

        private void timerDurationUpdater_Tick(object sender, EventArgs e)
        {
            _operationDuration = new TimeSpan(DateTime.Now.Ticks - _startedTime.Ticks);

            toolDuration.Text = "Duration: [" + _operationDuration.ToString(@"dd\:hh\:mm\:ss\.fff")+"]";
        }

        private void btnCleanScreen_Click(object sender, EventArgs e)
        {
            listboxSearchFolders.Items.Clear();
            txtGitignorePath.ResetText();
            txtLog.ResetText();

            configureControlEnability();

        }

        private void btnRunCleaner_MouseEnter(object sender, EventArgs e)
        {
            btnRunCleaner.BackColor = Color.Green;
        }

        private void btnRunCleaner_MouseLeave(object sender, EventArgs e)
        {
            btnRunCleaner.BackColor = Color.Lime;
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {

        }
    }
}
