﻿using swap_faces.Dto;

namespace swap_faces.Helpers
{
    public interface IShellHelper
    {
        /// <summary>
        /// Executes a list of commands on the shell, capturing stdout and stderr
        /// </summary>
        ExecuteResultEx ExecuteWithTimeout(string[] commands, string? workingDirectory = null, int timeoutMinutes = 15, Action<string> stdErrDataReceivedCallback = null, Action<string> stdOutDataReceivedCallback = null);
        /// <summary>
        /// Executes a command on the shell, capturing stdout and stderr
        /// </summary>
        ExecuteResult Execute(string cmd, Action<string> stdErrDataReceivedCallback = null, Action<string> stdOutDataReceivedCallback = null);
        /// <summary>
        /// Sanitizes a file name
        /// </summary>
        string SanitizeFilename(string filename);
    }
}
