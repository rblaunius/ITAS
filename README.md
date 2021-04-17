# Integrated Telescope Automation System (ITAS)

Software Design Report
Barrett Launius
Spring 2020 
 
# I. Introduction
This basis of this project was to update, re-design, and migrate an old version of SFA’s Telescope Software called ITAS (Integrated Telescope Automation System). It is used at the University’s observatory to track objects using one of two large telescopes. The original software was last updated in 2006 by Dr. Bruton and was written in VB6 – a framework that was discontinued about fifteen years ago. Under the guidance and supervision of Dr. Timmons, I was tasked with the challenge of converting the outdated software into a more modern application that is easier to use and modify by migrating from VB6 to the VB.NET framework.

In a nutshell, ITAS is simply an interface that stores coordinates and other information of objects viewed by the telescope and allows the observer to orient the telescope quickly. The hand paddle created last semester will be used to provide additional functionality to interface between the software and the telescope orientation. Unfortunately, the Corona Virus outbreak has hindered the progress of many features in the updated version of ITAS, including the implementation of the hand paddle, telescope controls, and third-party application support with theSky. The following report will describe in detail what has been accomplished in the last few months.

# II. Startup/Background Application
In ITAS version 1.0 (the original VB6 application), a startup screen opens every time a user starts the program. After entering his or her initials, a log file will be created to record most actions that take place in the main application. Figures 1 and 2 show a comparison between the old and new startup screens.

Figure 1: ITAS v1.0 Startup Window

Figure 2: ITAS v2.0 Startup Window

The functionality of the startup window in version 2.0 is nearly identical to the original; however, the operator now has the option for the system to automatically login the previous user, which can bypass the startup screen. The log file will create and save a new file per user; however, if the user already has an existing file, it will add to the existing one. This is a feature that can be easily modified if it’s unnecessary. The log file is saved to the same directory as before, but because version 1.0 does not work with Windows 10, there was some ambiguity in the content stored in the log file. The current system saves information like the type of telescope and timestamps for each action. More commands will be added in the future.

# III. Main Application
After the log file has been initialized, the main window appears. The main window contains the bulk of the application and is similar to the previous version but has slight improvements. Both versions are shown below in Figures 3 and 4.

Figure 3: ITAS v1.0 Main Window

Figure 4: ITAS v2.0 Main Window

The most obvious change is the data structure of the star catalog. In the old version, the list of sky objects was displayed as text within a panel. In the updated version, a data table was used. The data is still stored and retrieved from a text file but is now displayed like an excel sheet. Sorting data is much easier this way because the operator simply has to click the title at the top of the table to sort by variable. By doing this, it eliminates the need for the “sorting” buttons shown above the catalog in Figure 3. Because this eliminates the need for these buttons, a search feature was implemented to quickly search for the star in the catalog and selects the object automatically. More details of the data table are in Section IV-D.

Another difference between the two applications is the menu toolbar. From left to right, we have File, View, Edit, Tools, and Help drop-down menus to organize the functions added to the software. See Section IV for a list of each added toolbar.

Figure 5: Categorized Regions of Code within Main Form

There are also many new features and methods going on behind the scenes of this version of ITAS. First of all, I completely gutted the original ITAS software and started the new one from scratch. The file handling structure is efficient and easy to follow, with one “MasterFunctions.vb” file to control basic operations like writing to the log file, text file, debugging procedures, and more. Figure 5 shows the categories, or regions, of code in the main ITAS forms app. The main forms app contains code that populates and updates the menu, color preferences, form spacing, and commands for every button.

The implementation of the “My.Settings” functionality is also used to efficiently store preferences and user data. Unlike VB6, VBNET uses an internal data saving structure that saves settings within the compiled code every time the app closes (similar to “.ini” or “.dat” files but integrated within the application). The old software used a DLL to interface between the telescope, remote, and software, but this method is no longer necessary. VBNET has a feature that allows a serial port connection without using the DLL and runs/refreshes in real time. Other changes are mentioned in Section IV.

# IV. Details and Features

A. Graphics
Several old graphics were also gutted from the updated version of ITAS. Figure 6 shows the updated interactive graphic of the hand paddled (created last semester) used to display the remote controls. When the user hovers the mouse over any of the red buttons, a tool tip will appear describing what each button does. The icon for the software is also updated, created in Adobe Illustrator – shown in figure 7. The font and color schemes throughout the entire application is also slightly modified; it now uses Segoe UI font, a dark grey background for the buttons, and a darker red for the colors to reduce brightness. The font was also modified to include smooth edges and scales according to the size of the monitor.

B. Menu Toolbar
The old version only had three additional menu options. Below is a list of every toolbar drop-down category and the functionalities of their toolstrip menu items.

1. File – useful “shortcuts” for the application
a. Open Log File: This will simply open the user’s log file.
b. Switch User: This will “log out” and open up the startup window. This may be
useful if, for example, a student wants to use the software but a faculty
member is already logged in.
c. Exit: This exits the software completely.
2. View–visualpreferences
a. Enable/Disable Dark Mode: This will switch between the dark and light modes.
When dark, the title will read “Disable Night Mode” and vice versa. Figure 8 on the following page shows the light mode visual style. Under the Edit > Preferences window, the user can even select whether or not he/she wants ITAS to start up in dark mode or not.
 
 Figure 6: Hand Paddle Interactive Graphic
 
 Figure 7: Updated ITAS Icon

 Figure 8: Night Mode Disabled
 
3. Edit – miscellaneous controls and preferences
a. Sync To... This menu item was in the old version of ITAS and to my understanding,
it was intended to sync to a third-party app (theSky) and grab data from it. I’m not sure if it is still necessary but included it in the menu just in case. It’s also worth noting that every control relating to theSky/Sky Survey are not functional yet.
b. Preferences... This menu item will open another form/window: User Preferences. In this window, there are several options the user can edit. There are three tabs, shown in Figure 9. Currently, only the general tab is functional, but the telescope preferences tab will allow the operator to setup/select the telescope that is being used. The remote preferences tab will be used to setup the remote; although, the remote tab may be deemed unnecessary – depending on how the software will eventually recognize the connected remote. More settings can be added as necessary.

Figure 9: Preferences Window

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
C. Panels and Form Sizing
There are four panels inside the application to organize the content: ‘Current Object’ (displays the current object that the telescope is tracking), ‘Telescope’ (displays telescope tracking info), ‘Remote’ (displays remote interactive graphic), and ‘Next Object’ (displays all data/controls relating to setting up the coordinates for the telescope). The three panels on the left are identical to the original software, but the remote panel has an added feature/button to refresh the connection incase the user plugs in the device after the application starts. The ‘Next Object’ panel has significant changes, mentioned in Section III and part D of this section.
The old version of ITAS would not allow the user to maximize the window. The updated version gives complete access to maximize the window. However, in order to do this I had to scale every panel, button, and graphic to correct size depending on the window size. This was by far the most tedious work and still needs work – especially if things are added and modified in the future. The form sizing controls are located in the ‘frm_main.vb’ file in two independent private subs.
D. Data Table
As mentioned in previous sections, the data table is a new feature that organizes the catalog more efficiently than before. Although it is still far from finished, it works seamlessly with the software. As of now, the tabs that contain the data table (Bright Stars, Variable Stars, etc.) do not do anything and every tab, other than ‘Bright Stars’ is empty. Upon loading the main window, the software will import the data from the ‘starcatalog.txt’ file and sort the data into the cells in the table. Before, the operator could only sort by move time, sort alphabetically, and sort by right ascension. While these three sorting features are the most useful to search by, the actual buttons were unnecessary because the data table can sort all entries interactively.
After removing the sorting buttons, a search que feature was added in the space that the buttons were previously in. This might also be unnecessary, but it adds the capability to search for any star name in the catalog. It works by first creating an indexed array of all variables in the current configuration of the data table, then translating the queued text and each array string into lowercase, then searches for any match. For example, I one was search for “Galaxy” and was unsure which one, it will find the first data point with the word “galaxy” in the cell. Again, this needs more work but works as intended.
  8

# V. Incomplete Work and Future Improvements
Because of the current state of online classes/social distancing, I had limited access to complete everything I wanted to with the software. Several buttons/commands are incomplete and have no code attached to them. A list of Incomplete Work is shown below:
• USB Hand Paddle Implementation: Because I did not have access to the hand paddle during this time, I could not implement the controls and analog buttons on the physical remote. However, I did test some of the controls using a joystick and it should be an easy transition when I have access to the remote.
• Telescope Controls: This includes the serial port recognition, object tracking, frequency control, auto dome setting, and the main calibrated motor pulses. This is the “bread and butter” to the entire application but I could not find a way to implement the old functions into the software without having a serial port present. Also, because the old software used a DLL, it was hard – if not impossible for me to determine how to translate the old code into useable VBNET code. This is because I could not find any documentation on the ‘INPOUT32.dll’ and could not figure out what the various functions are intended to do in the original app. Because the telescope controls are not implemented, most of the main buttons do not work, including ‘SLEW TO’, the ‘load coordinates’ buttons, and the ‘reset guide rate report’ button. Once further clarification is given to me on these controls, it will be easy to implement.
• Current Object Panel: Right now, this panel only has placeholder text. It should be an easy fix when I find time to research more about using data tables inside a VBNET form. My main problem was figuring out how to index the “selected” star from the catalog and load it into the current object panel, because the index changes every time the operator sorts the table.
• TheSky: All references to the third-party app, TheSky, have no code attached because I do not have access to this software and am unsure what these commands do. This includes the following buttons: ‘Create Link with TheSky’, ‘Move TheSky to Next Object’, ‘Digital Sky Survey Image’, and the menu option ‘Sync To...’
• Catalog Entry Editor: The buttons, ‘Add to Catalog’ and ‘Remove from Catalog’ do not add or remove any entries to the text file as of yet. The reason I have not implemented code in these commands yet is because there is an option to add a new entry into the data table, sort of like adding a new row into an excel sheet. This, however, would completely change the data structure method of storing the objects in the catalog. If this was implemented, the text box entries directly under the ‘NEXT OBJECT’ label at the top left of the panel will be irrelevant. This is a user preference and I’m not sure what would better fit the needs of the operators at the observatory.
     9

As for future improvements, the most important improvements are obviously implementing the telescope and hand paddle controls into the software, as this is the bulk of the application. However, there are several minor things that are needed to add feasibility, reliability, and aesthetics to the overall application. Future Improvements are listed below:
• Search Feature: Currently, the search feature will search all items in the data table. If there is a way to store this data in a .csv file and easily access and modify the data, this would be the most ideal. Upon pressing the search button, the system will automatically select the first data entry found. However, using the last example when searching ‘Galaxy’, it will only select the first entry found in the algorithm. Ideally, the search feature should hide all data entries that do not contain the queued text in the search bar. This would also change the data structure of the catalog every time a search is performed so an alternate method of saving data would have to be used.
• Data Table Colors: As far as I am aware, the only way to change the background and foreground colors of the data table is to change every row/cell individually. For the ‘Light Mode’ (the visual mode depicted in Figure 8), no change is necessary to the data table. The ‘Dark Mode’, however, needs work on making (a) the background color to be black for every cell, (b) the foreground color (text color) to stay red, and (c) the highlighted selection color to be either a dark grey or a lighter shade of red. This would all be done in a separate sub function, ideally under the main form ‘Color/UI Preferences’ region in Figure 5.
• Next Object Data Tabs: Because a data table is being used, the option to sort by star/object type (Bright Star, Variable Star, Other Targets, Deep Sky, etc.) may be unnecessary. An extra column in the table could have the type of object (Bright/Variable/etc.) and could eliminate the need for tabs. Also, there is no way to change the color of these tabs because VBNET version 4.8 does not support this option.
• Preferences Window: The user preferences window should have more options under the general tab regarding color/appearance and other relevant controls. Because I do not know what would be useful to the operator, I left it with only the two options shown in Figure 9. The other two tabs are meant to setup the remote and telescope but could be eliminated if they are unnecessary once the telescope and remote settings are implemented into the software.
• Form Sizing: The form sizing algorithm of the updated version works pretty well, but still needs work resizing the data table whenever the form is maximized and minimized. There is a minimum size restraint on the entire form that might need to be increased slightly to fit the data table on startup.
• Miscellaneous: The ‘Refresh’ button next to the remote should simply refresh serial and USB detection functions to check if the correct remote was plugged into the machine. I would also like to add a panel that gathers any relevant data from an external .html website that provides information such as sunset time, moon status, humidity, etc. for a quick and easy reference to the live environment. This may also be unnecessary but could be useful.
      10

# VI. Conclusion
This was a fun project. I started this semester with no experience with Visual Studio, VB6, or VBNET, and ended the semester with a partially complete template for future work to be added by anyone with software development skills. I used skills like Photoshop/Illustrator, basic programming and commenting etiquette, and efficient file/data structure techniques to achieve the version I have (somewhat) completed. Although there is still lots of work needing to be done, I believe I have created the perfect template for a new version of ITAS.
This project sparked an interest in software development and allowed me to add a couple new skills to my resume including VBNET, Visual Studio, Simple Data Management, and GitHub Version Control. Although I am a mechanical engineering student, I am still keeping my career options open and have applied to several software development companies and have been looking into learning C# and C++ for basic application development.
The GitHub repository for all versions and progress in the application can be found in the following link: https://github.com/rblaunius/itas
 11
