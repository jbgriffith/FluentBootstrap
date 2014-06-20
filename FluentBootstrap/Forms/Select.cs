﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Forms
{
    public interface ISelect : IFormControl
    {
    }

    public class Select<TModel> : FormControl<TModel, Select<TModel>>, ISelect, IHasNameAttribute
    {
        internal List<string> Options { get; private set; }

        internal Select(BootstrapHelper<TModel> helper)
            : base(helper, "select", "form-control")
        {
            Options = new List<string>();
        }

        protected override void Prepare(System.IO.TextWriter writer)
        {
            base.Prepare(writer);

            // Add options as child tags
            foreach (string option in Options)
            {
                this.AddChild(new Tag<TModel>(Helper, "option")
                    .AddChild(new Content<TModel>(Helper, option)));
            }
        }
    }
}