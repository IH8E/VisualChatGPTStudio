﻿using Microsoft.VisualStudio.Shell;
using System;
using System.Runtime.InteropServices;
using Package = Microsoft.VisualStudio.Shell.Package;

namespace JeffPires.VisualChatGPTStudio.ToolWindows
{
    /// <summary>
    /// This class implements the tool window exposed by this package and hosts a user control.
    /// </summary>
    /// <remarks>
    /// In Visual Studio tool windows are composed of a frame (implemented by the shell) and a pane,
    /// usually implemented by the package implementer.
    /// <para>
    /// This class derives from the ToolWindowPane class provided from the MPF in order to use its
    /// implementation of the IVsUIElementPane interface.
    /// </para>
    /// </remarks>
    [Guid("904d9a5a-bbb5-47da-9531-d910e81fa928")]
    public class TerminalWindow : ToolWindowPane
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TerminalWindow"/> class.
        /// </summary>
        public TerminalWindow() : base(null)
        {
            this.Caption = "Visual chatGPT Studio";

            // This is the user control hosted by the tool window; Note that, even if this class implements IDisposable,
            // we are not calling Dispose on this object. This is because ToolWindowPane calls Dispose on
            // the object returned by the Content property.
            this.Content = new TerminalWindowControl();
        }

        protected override void OnCreate()
        {
            base.OnCreate();

            ((TerminalWindowControl)this.Content).StartControl(((VisuallChatGPTStudioPackage)this.Package).OptionsGeneral, (Package)this.Package);
        }

        /// <summary>
        /// Sends a request to the ChatGPT window.
        /// </summary>
        /// <param name="command">The command to send to the ChatGPT window.</param>
        /// <param name="selectedText">The selected text to be sent.</param>
        public async System.Threading.Tasks.Task RequestToWindowAsync(string command, string selectedText)
        {
            await ((TerminalWindowControl)this.Content).RequestToWindowAsync(command, selectedText);
        }
    }
}