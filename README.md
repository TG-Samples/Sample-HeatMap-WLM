# Heat Style Sample for WebAPI
HeatStyle allows you to better visualize data by making areas of high concentration “hotter” using warmer colors and low density areas visually cooler. In order to run this project, you will need the development build 10.0.0.0 or later.

![Screenshot](https://raw.githubusercontent.com/howardchn/Sample-OpenStreetMap-WLM/master/OpenStreetMap/Resources/Screenshot.jpg)

This guide will shows you how to depoly the WebAPI HeatStyle-WLO sample on Linux with Mono and debug with MonoDevelop.

## Setup Mono runtime and MonoDevelop IDE
  1. Prepaire a clean Ubuntu environment and the 14.04 is recommand.

  1. Press ==Ctrl== + ==Alt== + ==T== to open an terminal window. 

  1. Add the Mono Project GPG signing key and the package repository to your system (if you don’t use sudo, be sure to switch to root). Please issue flowing command line by line:
      ```perl
      sudo apt-key adv --keyserver hkp://keyserver.ubuntu.com:80 --recv-keys 3FA7E0328081BFF6A14DA29AA6A19B38D3D831EF

      echo "deb http://download.mono-project.com/repo/debian wheezy main" | sudo tee /etc/apt/sources.list.d/mono-xamarin.list

      sudo apt-get update
       ```
1. To Install mod_mono, we will need to add a second repository to OS, issue following command in terminal. 
	```perl
    echo "deb http://download.mono-project.com/repo/debian wheezy-apache24-compat main" | sudo tee -a /etc/apt/sources.list.d/mono-xamarin.list
    ```
1. Now it's time to install the mono environment, please issue following commands line by line, this step will take us few minitues depend on the network.
    ```perl
    sudo apt-get install mono-devel
    
    sudo apt-get install mono-complete
    
    sudo apt-get install referenceassemblies-pcl
    ```
    ***Notice***: Please enter **Y** when asking if you want to continue. *

1. It's time to install the IDE, currently our suggest is MonoDevelop, run following command to install **Mono Develop** on your computer.
	```perl
    sudo apt-get install monodevelop
    ```
1. Run `monodevelop` command in terminal to open MonoDevelop, Or we can click on left top corner of task bar to search **MonoDevelop** and run it. We can open Visual Studio solution file via **MonoDevelop**.
 
## Download Source code
1. We've hosted the source code on github at [https://github.com/howardchn/Sample-HeatMap-WLM.git](https://github.com/howardchn/Sample-HeatMap-WLM.git). clone the repository to local by:
	```perl
    git clone https://github.com/howardchn/Sample-HeatMap-WLM.git
    ```
    On the other hand, you can download it as zip via click the clone or download button shown in following screen shot.

1. Also you can download the **SmartGit** to download folder, then you need to issue following command in terminal to start **SmartGit**:
	```perl
    cd ~/Download
    
    ./smartgit/bin/smartgit.sh 
    ```