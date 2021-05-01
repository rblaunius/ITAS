# Integrated Telescope Automation System (ITAS)
Detailed Design Report
Barrett Launius

![ITAS](https://i.imgur.com/UaeS1yY.png)      ![ITAS2](https://i.imgur.com/l0EXgic.png)
 
# I. Introduction
This project involves the update, re-design, and migration of an old version of SFA’s Telescope Software called ITAS (Integrated Telescope Automation System). It is used at the University’s observatory to track objects using one of two large telescopes. My task was to convert the outdated software into a more modern application that is easier to use and modify by migrating from VB6 to the VB.NET Framework.

ITAS is an interface that stores coordinates and other information of objects viewed by the telescope, and allows the observer to orient the telescope quickly. The hand paddle created in tandem will be used to provide additional functionality to interface between the software and the telescope orientation. The following report will describe in detail what has been accomplished in the last few months.

# II. Funcitonality - Startup
In ITAS version 1.0 (the original VB6 application), a startup screen opens every time a user starts the program. After entering his or her initials, a log file will be created to record most actions that take place in the main application. The functionality of the startup window in version 2.0 is nearly identical to the original; however, the operator now has the option for the system to automatically login the previous user, which can bypass the startup screen. The log file will create and save a new file per user; however, if the user already has an existing file, it will add to the existing one. This is a feature that can be easily modified if it’s unnecessary. The log file is saved to the same directory as before, but because version 1.0 does not work with Windows 10, there was some ambiguity in the content stored in the log file. The current system saves information like the type of telescope and timestamps for each action. More commands will be added in the future.

# III. Funcitonality - Main Application
After the log file has been initialized, the main window appears. The main window contains the bulk of the application and is similar to the previous version but has slight improvements.

The most obvious change is the data structure of the star catalog. In the old version, the list of sky objects was displayed as text within a panel. In the updated version, a data table was used. The data is still stored and retrieved from a text file but is now displayed like an excel sheet. Sorting data is much easier this way because the operator simply has to click the title at the top of the table to sort by variable. By doing this, it eliminates the need for the “sorting” buttons shown above the catalog in Figure 3. Because this eliminates the need for these buttons, a search feature was implemented to quickly search for the star in the catalog and selects the object automatically. More details of the data table are in Section IV-D.

Another difference between the two applications is the menu toolbar. From left to right, we have File, View, Edit, Tools, and Help drop-down menus to organize the functions added to the software. See Section IV for a list of each added toolbar.

There are also many new features and methods going on behind the scenes of this version of ITAS. First of all, I completely gutted the original ITAS software and started the new one from scratch. The file handling structure is efficient and easy to follow, with one “MasterFunctions.vb” file to control basic operations like writing to the log file, text file, debugging procedures, and more. Figure 5 shows the categories, or regions, of code in the main ITAS forms app. The main forms app contains code that populates and updates the menu, color preferences, form spacing, and commands for every button.

The implementation of the “My.Settings” functionality is also used to efficiently store preferences and user data. Unlike VB6, VBNET uses an internal data saving structure that saves settings within the compiled code every time the app closes (similar to “.ini” or “.dat” files but integrated within the application). The old software used a DLL to interface between the telescope, remote, and software, but this method is no longer necessary. VBNET has a feature that allows a serial port connection without using the DLL and runs/refreshes in real time. Other changes are mentioned in Section IV.

# IV. Details and Features

A. **Graphics**

Several old graphics were also gutted from the updated version of ITAS. Figure 6 shows the updated interactive graphic of the hand paddled (created last semester) used to display the remote controls. When the user hovers the mouse over any of the red buttons, a tool tip will appear describing what each button does. The icon for the software is also updated, created in Adobe Illustrator – shown in figure 7. The font and color schemes throughout the entire application is also slightly modified; it now uses Segoe UI font, a dark grey background for the buttons, and a darker red for the colors to reduce brightness. The font was also modified to include smooth edges and scales according to the size of the monitor.

B. **Menu Toolbar**

The old version only had three additional menu options. Below is a list of every toolbar drop-down category and the functionalities of their toolstrip menu items.

1. File – useful “shortcuts” for the application
 a. Open Log File: This will simply open the user’s log file.
 b. Switch User: This will “log out” and open up the startup window. This may be
useful if, for example, a student wants to use the software but a faculty
member is already logged in.
 c. Exit: This exits the software completely.
 
2. View–visualpreferences
 a. Enable/Disable Dark Mode: This will switch between the dark and light modes. When dark, the title will read “Disable Night Mode” and vice versa. 
 
3. Edit – miscellaneous controls and preferences
 a. Sync To... This menu item was in the old version of ITAS and to my understanding,
it was intended to sync to a third-party app (theSky) and grab data from it. I’m not sure if it is still necessary but included it in the menu just in case. It’s also worth noting that every control relating to theSky/Sky Survey are not functional yet.
 b. Preferences... This menu item will open another form/window: User Preferences. In this window, there are several options the user can edit. There are three tabs. Currently, only the general tab is functional, but the telescope preferences tab will allow the operator to setup/select the telescope that is being used. The remote preferences tab will be used to setup the remote; although, the remote tab may be deemed unnecessary – depending on how the software will eventually recognize the connected remote. More settings can be added as necessary.
 
4. Tools
 a. TheSky: This will launch the third-party app “TheSky” once it has been implemented.
 b. Google Earth: Again, I am unsure if this is even necessary, but this will launch the
online version of google earth in the default browser and will load the coordinates of the SFA observatory. Here, you can find information like the sunset, weather conditions, etc.

5. Help – references to external resources
 a. Documentation: Opens the old ITAS documentation website. In the future, an
updated website will be used.
 b. GitHub: Opens the GitHub repository for the current build/version for easy access to
developers.

6. DEBUG – Opens the debug window. This will be removed in the final build but is useful to
see events and test buttons/controls without it affecting or corrupting the main form.

C. **Panels and Form Sizing**

There are four panels inside the application to organize the content: ‘Current Object’ (displays the current object that the telescope is tracking), ‘Telescope’ (displays telescope tracking info), ‘Remote’ (displays remote interactive graphic), and ‘Next Object’ (displays all data/controls relating to setting up the coordinates for the telescope). The three panels on the left are identical to the original software, but the remote panel has an added feature/button to refresh the connection incase the user plugs in the device after the application starts. The ‘Next Object’ panel has significant changes, mentioned in Section III and part D of this section.

The old version of ITAS would not allow the user to maximize the window. The updated version gives complete access to maximize the window. However, in order to do this I had to scale every panel, button, and graphic to correct size depending on the window size. This was by far the most tedious work and still needs work – especially if things are added and modified in the future. The form sizing controls are located in the ‘frm_main.vb’ file in two independent private subs.

D. **Data Table**

As mentioned in previous sections, the data table is a new feature that organizes the catalog more efficiently than before. Although it is still far from finished, it works seamlessly with the software. As of now, the tabs that contain the data table (Bright Stars, Variable Stars, etc.) do not do anything and every tab, other than ‘Bright Stars’ is empty. Upon loading the main window, the software will import the data from the ‘starcatalog.txt’ file and sort the data into the cells in the table. Before, the operator could only sort by move time, sort alphabetically, and sort by right ascension. While these three sorting features are the most useful to search by, the actual buttons were unnecessary because the data table can sort all entries interactively.
After removing the sorting buttons, a search que feature was added in the space that the buttons were previously in. This might also be unnecessary, but it adds the capability to search for any star name in the catalog. It works by first creating an indexed array of all variables in the current configuration of the data table, then translating the queued text and each array string into lowercase, then searches for any match. For example, I one was search for “Galaxy” and was unsure which one, it will find the first data point with the word “galaxy” in the cell.
