using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace LegacyPVP.Logic.PageLogic
{
    public class PageLogic
    {
        internal static ContentControl MainGrid;
        internal static ContentControl SecondaryGrid;
        internal static ContentControl OverlayGrid;
        internal static MainWindow Win;
        internal static Type CurrentPage;

        /// <summary>
        /// Switches the pages before login
        /// </summary>
        /// <typeparam name="T">The page</typeparam>
        /// <param name="Fade">Fade out the page?</param>
        /// <param name="Arguments">Arguments</param>
        internal static void SwichMaserPage<T>(bool Fade = true, params object[] Arguments)
        {
            if (CurrentPage == typeof(T))
                return;

            Page instance = (Page)Activator.CreateInstance(typeof(T), Arguments);
            CurrentPage = typeof(T);

            if (Fade)
            {
                var fadeOutAnimation = new DoubleAnimation(0, TimeSpan.FromSeconds(0.25));
                fadeOutAnimation.Completed += (x, y) =>
                {
                    MainGrid.Content = instance.Content;
                    var fadeInAnimation = new DoubleAnimation(1, TimeSpan.FromSeconds(0.25));
                    MainGrid.BeginAnimation(ContentControl.OpacityProperty, fadeInAnimation);
                };
                MainGrid.BeginAnimation(ContentControl.OpacityProperty, fadeOutAnimation);
            }
            else
            {
                MainGrid.Content = instance.Content;
            }
        }

        /// <summary>
        /// Use this to switch pages after loggin
        /// </summary>
        /// <typeparam name="T">What is the page you want to switch to</typeparam>
        /// <param name="Fade">Fade out the page?</param>
        /// <param name="Arguments">Arguments durp</param>
        internal static void SwichPage<T>(bool Fade = false, params object[] Arguments)
        {
            if (CurrentPage == typeof(T))
                return;

            Page instance = (Page)Activator.CreateInstance(typeof(T), Arguments);
            CurrentPage = typeof(T);

            if (Fade)
            {
                var fadeOutAnimation = new DoubleAnimation(0, TimeSpan.FromSeconds(0.25));
                fadeOutAnimation.Completed += (x, y) =>
                {
                    SecondaryGrid.Content = instance.Content;
                    var fadeInAnimation = new DoubleAnimation(1, TimeSpan.FromSeconds(0.25));
                    SecondaryGrid.BeginAnimation(ContentControl.OpacityProperty, fadeInAnimation);
                };
                SecondaryGrid.BeginAnimation(ContentControl.OpacityProperty, fadeOutAnimation);
            }
            else
            {
                SecondaryGrid.Content = instance.Content;
            }
        }

        /// <summary>
        /// Show an overlay that does not need special arguments
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Arguments"></param>
        internal static void Overlay<T>(params object[] Arguments)
        {
            var moveAnimation = new ThicknessAnimation(new Thickness(0, 0, 0, 0), TimeSpan.FromSeconds(0.5));
            OverlayGrid.Margin = new Thickness(1357, 0, -1357, 0);
            Page instance = (Page)Activator.CreateInstance(typeof(T), Arguments);
            OverlayGrid.Content = instance.Content;
            OverlayGrid.Visibility = Visibility.Visible;
            OverlayGrid.BeginAnimation(Grid.MarginProperty, moveAnimation);
        }

        /// <summary>
        /// To allow a user to make an overlay of a element that requires setting special arguments
        /// </summary>
        /// <param name="page">What is the page</param>
        /// <param name="thickness">use new Thickness(1357, 0, -1357, 0) to slide from top</param>
        /// <param name="speed">How fast do you want the overlay to be</param>
        internal static void DoNormalOverlay(Page page, Thickness thickness, double speed = 0.5)
        {
            var moveAnimation = new ThicknessAnimation(new Thickness(0, 0, 0, 0), TimeSpan.FromSeconds(speed));
            OverlayGrid.Margin = thickness;
            Page instance = page;
            OverlayGrid.Content = instance.Content;
            OverlayGrid.Visibility = Visibility.Visible;
            OverlayGrid.BeginAnimation(Grid.MarginProperty, moveAnimation);
        }

        /// <summary>
        /// Hide the overlay, Regardless of what it is
        /// </summary>
        /// <param name="thickness">Where do you want it to slide to</param>
        internal static void HideOverlay(Thickness thickness)
        {
            var moveAnimation = new ThicknessAnimation(thickness, TimeSpan.FromSeconds(0.5));
            OverlayGrid.BeginAnimation(Grid.MarginProperty, moveAnimation);
        }

        /// <summary>
        /// Focus the window
        /// </summary>
        public static void FocusWindow()
        {
            Win.Focus();
        }

        internal static void ClearPage(Page page)
        {

        }
    }
}
