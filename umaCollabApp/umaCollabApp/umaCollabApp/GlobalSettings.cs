using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using umaCollabApp.Views;
using Xamarin.Forms;

namespace umaCollabApp
{
    //Global setting guarda o id do utilizor autenticado 
    #region singleton;
    class GlobalSettings : Application
    {
        public static int currentUserId { get; set; } 
    }
    #endregion 
}
