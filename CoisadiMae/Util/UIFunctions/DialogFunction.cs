using System;
using Acr.UserDialogs;
using CoisadiMae.Util.Enums;
using Xamarin.Forms;

namespace CoisadiMae.Util.UIFunctions
{
    /// <summary>
    /// Dialogs functions.
    /// </summary>
	public class DialogsFunction : IDialogsFunction
	{
		public IUserDialogs _userDialogs;

		public DialogsFunction(IUserDialogs userDialogs)
		{
			_userDialogs = userDialogs;
		}

        /// <summary>
        /// Hides the loading.
        /// </summary>
		public void HideLoading()
		{
			Device.BeginInvokeOnMainThread(() => _userDialogs.HideLoading());
		}

        /// <summary>
        /// Shows the alert.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="timeout">Timeout.</param>
		public void ShowAlert(string message, int? timeout = default(int?))
		{
			var config = new AlertConfig
			{
				Message = string.Empty,
				OkText = "OK",
				Title = message
			};

			Device.BeginInvokeOnMainThread(() => _userDialogs.Alert(config));
		}

        /// <summary>
        /// Shows the loading.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="timeout">Timeout.</param>
		public void ShowLoading(string message, int? timeout = default(int?))
		{
			Device.BeginInvokeOnMainThread(() => _userDialogs.ShowLoading(message));
		}

        /// <summary>
        /// Shows the toast.
        /// </summary>
        /// <param name="type">Type.</param>
        /// <param name="message">Message.</param>
        /// <param name="timeout">Timeout.</param>
		public void ShowToast(EnumToastType type, string message, int timeout = 5000)
		{
			ToastConfig config = new ToastConfig(message)
			{
				Message = message,
				Duration = TimeSpan.FromMilliseconds(timeout),
				MessageTextColor = System.Drawing.Color.White,
				BackgroundColor = type == EnumToastType.Error ?
										  System.Drawing.Color.Crimson :
										  type == EnumToastType.Info || type == EnumToastType.Warning ?
										  System.Drawing.Color.Goldenrod :
										  System.Drawing.Color.Green
			};

			Device.BeginInvokeOnMainThread(() => _userDialogs.Toast(config));
		}
	}
}