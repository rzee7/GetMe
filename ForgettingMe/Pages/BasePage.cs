using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ForgettingMe
{
    public class BasePage : ContentPage
    {
        public BasePage()
        {
            ToolbarItems.Add(new ToolbarItem("+", "", async () =>
            {
                var page = new ContentPage();
                var result = await page.DisplayAlert("Title", "Message", "Accept", "Cancel");
            }));
        }
    }
}
