using System;
using CoisadiMae.Util.Enums;

namespace CoisadiMae.Util.UIFunctions
{
    /// <summary>
    /// Dialogs function.
    /// </summary>
    public interface IDialogsFunction
    {
		void ShowAlert(string message, int? timeout = null);
		void ShowLoading(string message, int? timeout = null);
		void HideLoading();
		void ShowToast(EnumToastType type, string message, int timeout = 5000);
    }
}