# Project Cleaner

# .gitignore based folder cleaner

<img title="" src="assets/bd83635cca6588ea4c19c3ac3b63da0c9424e4cd.png" alt="app.png" width="243" data-align="center">

## Usage

![](assets/2022-01-03-02-04-08-image.png)

- If you have a .gitignore file, drag-drop it to textbox near select .gitignore and set your gitignore file. 

- If you do not have a .gitignore file, please use open gitignore builder and download content as file .gitignore. 

- Drag-drop your folders that contains projects

- Click Run Cleaner

- If you have Doxygen generated outputs to clean. A Doxygen configuration reader tries to find out the output folder and delete it. 

- You can stop with the stop cleaner button. 

![](assets/2022-01-03-02-08-23-image.png)

## Development

### Visual Studio 2022 for Project Development

Install Visual Studio 2022

[Visual Studio 2022 Community Edition – Son Ücretsiz Sürümü İndir](https://visualstudio.microsoft.com/tr/vs/community/)

### Wix Toolkit for Setup Generation

**Step-1** Enable .Net 3.5.1 Components

Open Turn Windows Features On of Off Menu

![](assets/2022-01-06-13-39-11-image.png)

Check .Net Framework 3.5 

![](assets/2022-01-06-13-40-43-image.png)

Complete Setup

**Step-2** Download and  Install Wix Toolkit and Visual Studio 2022 Extension

[Downloads](https://wixtoolset.org/releases/)

**Step-3** After installation, if you have a reference problem, you need to configure DLLs from the path such as "WixUIExtension.dll."

```textile
C:\Program Files (x86)\WiX Toolset v3.11\bin
```

### References

**Git Auto Increment Tool**

[GitHub - jeromerg/NGitVersion: Automatic versioning of C# and C++ DLLs (CLI and Native) based on Git Repository information](https://github.com/jeromerg/NGitVersion)

**Advanced Wix Setup**

[Real-World Example: WiX/MSI Application Installer &bull; Helge Klein](https://helgeklein.com/blog/real-world-example-wix-msi-application-installer/)

**Wix Editor**

https://wixedit.github.io/

**Wix Standalone Setup Toolkit for Github Actions**

[GitHub - fbarresi/wix: wix standalone - checkout this repo to build wix project inside github action](https://github.com/fbarresi/wix)
