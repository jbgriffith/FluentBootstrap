﻿using FluentBootstrap.Images;
using FluentBootstrap.Links;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.MediaObjects
{
    public interface IMediaObjectCreator<THelper> : IComponentCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    public class MediaObjectWrapper<THelper> : TagWrapper<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    internal interface IMediaObject : ITag
    {
    }

    public class MediaObject<THelper> : Tag<THelper, MediaObject<THelper>, MediaObjectWrapper<THelper>>, IMediaObject, IHasLinkExtensions
        where THelper : BootstrapHelper<THelper>
    {
        internal string Src { get; set; }
        internal string Alt { get; set; }
        private Image<THelper> _image;

        internal MediaObject(IComponentCreator<THelper> creator)
            : base(creator, "a", Css.MediaLeft)
        {
        }

        protected override void OnStart(TextWriter writer)
        {
            // Change to a div if no link was provided
            string href = GetAttribute("href");
            if (string.IsNullOrWhiteSpace(href))
            {
                TagName = "div";
            }

            base.OnStart(writer);

            _image = Helper.Image(Src, Alt);
            _image.Start(writer);
        }

        protected override void OnFinish(TextWriter writer)
        {
            _image.Finish(writer);

            base.OnFinish(writer);
        }
    }
}
