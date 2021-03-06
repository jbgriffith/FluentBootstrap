﻿using FluentBootstrap.Html;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Navbars
{
    public interface INavbarToggleCreator<THelper> : IComponentCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    public class NavbarToggleWrapper<THelper> : TagWrapper<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    internal interface INavbarToggle : ITag
    {
    }

    public class NavbarToggle<THelper> : Tag<THelper, NavbarToggle<THelper>, NavbarToggleWrapper<THelper>>, INavbarToggle
        where THelper : BootstrapHelper<THelper>
    {
        internal string DataTarget { get; set; }
        internal bool Hamburger { get; set; }

        internal NavbarToggle(IComponentCreator<THelper> creator)
            : base(creator, "button", Css.NavbarToggle, "collapsed")
        {
            Hamburger = true;
            this.MergeAttribute("type", "button");
            this.MergeAttribute("data-toggle", "collapse");
        }
        
        protected override void OnStart(TextWriter writer)
        {
            // Set the data-target
            if (string.IsNullOrWhiteSpace(DataTarget))
            {
                // Get the Navbar ID and use it to set the data-target
                string navbarId = string.Empty;
                INavbar navbar = GetComponent<INavbar>();
                if (navbar != null)
                {
                    navbarId = navbar.GetAttribute("id");
                }
                DataTarget = "#" + navbarId + "-collapse";
            }
            this.MergeAttribute("data-target", DataTarget);

            // Make sure we're in a header, but only if we're also in a navbar
            INavbarHeader header = GetComponent<INavbarHeader>();
            if (GetComponent<INavbar>() != null && header == null)
            {
                new NavbarHeader<THelper>(Helper).Start(writer);
            }
            else if(header != null)
            {
                header.HasToggle = true;
            }

            base.OnStart(writer);

            Helper.Span().AddCss(Css.SrOnly).SetText("Toggle Navigation").StartAndFinish(writer);
            if (Hamburger)
            {
                Helper.Span().AddCss(Css.IconBar).StartAndFinish(writer);
                Helper.Span().AddCss(Css.IconBar).StartAndFinish(writer);
                Helper.Span().AddCss(Css.IconBar).StartAndFinish(writer);
            }
        }
    }
}
