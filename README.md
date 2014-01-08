MagicJackSvcCreator
===================

This is a Windows app for people using a magicJack VOIP device, written in C#. It is designed to remove the desktop software phone and create a Windows service that operates the device. Once the service is installed, the user has the option to remove the service and revert to the original setup. Benefits/features:

- No more UI popups or desktop phone call notifications
- MagicJack is functional even when user is logged off, and works under all user accounts
- No splash screen or waiting for MagicJack to load
- MagicJack receives higher network and CPU priority when run as a service
- Stand-alone app (does not install itself on your PC or need to run in the background)
- Revert back to OEM settings with one click

You can get the compiled exe at www.evanvaughan.com/magicjack.aspx

Please note that this Github version is a "vanilla" version. Unlike the version available for download on my site, this version does not have a donate button, and does not automatically check for updates when run.

Feel free to improve, distribute, and use this code without any restrictions. For questions, or just to drop me a line letting me know that you fixed or improved something: evan@evanvaughan.com
