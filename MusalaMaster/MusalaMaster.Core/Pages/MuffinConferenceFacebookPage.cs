using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusalaMaster.Core.Pages
{
    public class MuffinConferenceFacebookPage : BasePage
    {
        public MuffinConferenceFacebookPage(IWebDriver driver) 
            : base(driver)
        {
        }

        public override string Url => "https://www.facebook.com/MUFFINconference";

        public IWebElement ProfilePicture => Driver.FindElement(By.CssSelector("[src='https://scontent.fsof6-1.fna.fbcdn.net/v/t1.0-1/p200x200/42965138_1113744825466495_6172932954377945088_n.jpg?_nc_cat=102&_nc_sid=dbb9e7&_nc_ohc=2D34eATZYIkAX88Yx4s&_nc_ht=scontent.fsof6-1.fna&_nc_tp=6&oh=0b92121d54f75e3229520b68e9f4a137&oe=5F501D15']"));

        public void EnsureProfilePictureExist()
        {
            Assert.IsTrue(ProfilePicture.Displayed);
        }
    }
}
