using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace umaCollabApp.Interfaces
{
    public interface IMessage
    {
        // Interface responsável pela exibição de mensagens

        Task<string> DisplayActionSheet(string title, string cancel, string destruction, params string[] buttons);
        //
        // Summary:
        //     Presents an alert dialog to the application user with a single cancel button.
        //
        // Parameters:
        //   title:
        //     The title of the alert dialog.
        //
        //   message:
        //     The body text of the alert dialog.
        //
        //   cancel:
        //     Text to be displayed on the 'Cancel' button.
        //
        // Returns:
        //     To be added.
        //
        // Remarks:
        //     To be added.
        Task DisplayAlert(string title, string message, string cancel);
        //
        // Summary:
        //     Presents an alert dialog to the application user with an accept and a cancel
        //     button.
        //
        // Parameters:
        //   title:
        //     The title of the alert dialog.
        //
        //   message:
        //     The body text of the alert dialog.
        //
        //   accept:
        //     Text to be displayed on the 'Accept' button.
        //
        //   cancel:
        //     Text to be displayed on the 'Cancel' button.
        //
        // Returns:
        //     To be added.
        //
        // Remarks:
        //     To be added.
        Task<bool> DisplayAlert(string title, string message, string accept, string cancel);
    }
}
