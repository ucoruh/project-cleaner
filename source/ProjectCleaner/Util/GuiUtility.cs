using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectCleaner.Util
{
    internal class GuiUtility
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="btn"></param>
        /// <param name="color"></param>
        public static void UpdateButtonText(ToolStrip tooStrip, ToolStripButton toolStripbtn, string text)
        {
            if (tooStrip != null)
            {
                if (!tooStrip.IsDisposed && !tooStrip.Parent.IsDisposed)
                {
                    if (tooStrip.InvokeRequired)
                    {
                        tooStrip.Invoke(new MethodInvoker(delegate
                        {
                            toolStripbtn.Text = text;
                            tooStrip.Refresh();
                        }));
                    }
                    else
                    {
                        toolStripbtn.Text = text;
                        tooStrip.Refresh();
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="btn"></param>
        /// <param name="color"></param>
        public static void UpdateControlEnabled(Control cntrl, bool enabled)
        {
            if (cntrl != null)
            {
                if (!cntrl.IsDisposed && !cntrl.Parent.IsDisposed)
                {
                    if (cntrl.InvokeRequired)
                    {
                        cntrl.Invoke(new MethodInvoker(delegate
                        {
                            cntrl.Enabled = enabled;
                            cntrl.Refresh();
                        }));
                    }
                    else
                    {
                        cntrl.Enabled = enabled;
                        cntrl.Refresh();
                    }
                }
            }
        }

        public static void UpdateControlText(Control lbl, string text)
        {
            if (lbl != null)
            {
                if (!lbl.IsDisposed && !lbl.Parent.IsDisposed)
                {
                    if (lbl.InvokeRequired)
                    {
                        lbl.Invoke(new MethodInvoker(delegate
                        {
                            lbl.Text = text;
                            lbl.Refresh();
                        }));
                    }
                    else
                    {
                        lbl.Text = text;
                        lbl.Refresh();
                    }

                }
            }
        }


        //public static void LogTextEvent(RichTextBox TextEventLog, Color TextColor, string EventText)
        //{
        //    if (TextEventLog.InvokeRequired)
        //    {
        //        TextEventLog.BeginInvoke(new Action(delegate {
        //            LogTextEvent(TextEventLog, TextColor, EventText);
        //        }));
        //        return;
        //    }

        //    string nDateTime = DateTime.Now.ToString("hh:mm:ss tt") + " - ";

        //    // color text.
        //    TextEventLog.SelectionStart = TextEventLog.Text.Length;
        //    TextEventLog.SelectionColor = TextColor;

        //    // newline if first line, append if else.
        //    if (TextEventLog.Lines.Length == 0)
        //    {
        //        TextEventLog.AppendText(nDateTime + EventText);
        //        TextEventLog.ScrollToCaret();
        //        TextEventLog.AppendText(System.Environment.NewLine);
        //    }
        //    else
        //    {
        //        TextEventLog.AppendText(nDateTime + EventText + System.Environment.NewLine);
        //        TextEventLog.ScrollToCaret();
        //    }

        //}

        public static void LogTextEvent(RichTextBox TextEventLog, Color TextColor, string EventText)
        {

            if (TextEventLog != null)
            {
                if (!TextEventLog.IsDisposed && !TextEventLog.Parent.IsDisposed)
                {
                    if (TextEventLog.InvokeRequired)
                    {
                        TextEventLog.Invoke(new MethodInvoker(delegate
                        {
                            string nDateTime = DateTime.Now.ToString("hh:mm:ss tt") + " - ";

                            // color text.
                            TextEventLog.SelectionStart = TextEventLog.Text.Length;
                            TextEventLog.SelectionColor = TextColor;

                            // newline if first line, append if else.
                            if (TextEventLog.Lines.Length == 0)
                            {
                                TextEventLog.AppendText(nDateTime + EventText);
                                TextEventLog.ScrollToCaret();
                                TextEventLog.AppendText(System.Environment.NewLine);
                            }
                            else
                            {
                                TextEventLog.AppendText(nDateTime + EventText + System.Environment.NewLine);
                                TextEventLog.ScrollToCaret();
                            }

                            TextEventLog.Refresh();

                        }));
                    }
                    else
                    {
                        string nDateTime = DateTime.Now.ToString("hh:mm:ss tt") + " - ";

                        // color text.
                        TextEventLog.SelectionStart = TextEventLog.Text.Length;
                        TextEventLog.SelectionColor = TextColor;

                        // newline if first line, append if else.
                        if (TextEventLog.Lines.Length == 0)
                        {
                            TextEventLog.AppendText(nDateTime + EventText);
                            TextEventLog.ScrollToCaret();
                            TextEventLog.AppendText(System.Environment.NewLine);
                        }
                        else
                        {
                            TextEventLog.AppendText(nDateTime + EventText + System.Environment.NewLine);
                            TextEventLog.ScrollToCaret();
                        }

                        TextEventLog.Refresh();
                    }

                }
            }

        }
    }
}
