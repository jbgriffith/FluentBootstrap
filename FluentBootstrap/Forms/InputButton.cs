﻿using FluentBootstrap.Buttons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Forms
{
    public interface IInputButtonCreator<THelper> : IComponentCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    public class InputButtonWrapper<THelper> : FormControlWrapper<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    internal interface IInputButton : IFormControl
    {
    }

    public class InputButton<THelper> : FormControl<THelper, InputButton<THelper>, InputButtonWrapper<THelper>>, 
        IInputButton, IHasButtonExtensions, IHasButtonStateExtensions, IHasDisabledAttribute, IHasTextContent, IHasValueAttribute, IHasNameAttribute
        where THelper : BootstrapHelper<THelper>
    {
        internal InputButton(IComponentCreator<THelper> creator, ButtonType buttonType)
            : base(creator, "input", Css.Btn, Css.BtnDefault)
        {
            MergeAttribute("type", buttonType.GetDescription());
        }

        protected override bool OutputEndTag
        {
            get { return false; }
        }
    }
}
