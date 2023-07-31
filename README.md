# Pikmin 4 Mixer
This GUI will take your Pikmin 4 audio files and group them based on their duration. You can then play the audio files within these groups simultaneously and mix them. You can use this to create the many different variants of Pikmin 4's songs. The grouping method assumes that not every song is the exact same duration, and while that is mostly true, there could be some exceptions (to be listed).

### Things this can do:
- Converts WEM to WAV for you in a nice little GUI
- Groups your audio files based on duration automatically
- Plays the groups simultaneously with mixer volume control
- Exports mixes in WAV or MP3 format
- Let's you label files and saves them in a dictionary, the dictionary supports Import/Export of CSV format, allowing you to share your dictionary with the world

### Some controls
- In the mixer, the checkboxes mute/unmute that layer
- You can right-click the checkbox to mute all layers except that layer (right-click again to unmute all other layers)
- Some keyboard shortcuts are built-in, see the menu strip at the top-left for most of them; Ctrl+C will open the Convert WEM to WAV menu
- Double-click a filename in the mixer to give it a label
- Use the dictionary (File > Manage Dictionary...) to share or import CSV dictionaries.
- You can drag-and-drop a folder containing your WAVs straight onto the left-most listbox, and when you open the tool another time, Ctrl-Z will re-open that folder

Since this is a fairly basic utility, only minor improvemnts can be made. Feel free to open issues or pull requests.

![Pikmin 4 Mixer Main Window](https://i.imgur.com/N5DD1vI.png)
![Pikmin 4 Mixer Dictionary](https://i.imgur.com/LHj58OS.png)
![Pikmin 4 Mixer WEM Converter](https://i.imgur.com/1Om92aU.png)
