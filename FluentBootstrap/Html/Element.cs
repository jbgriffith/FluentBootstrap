﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Html
{
    public interface IElementCreator<THelper> : IComponentCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    public class ElementWrapper<THelper> : TagWrapper<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    internal interface IElement : ITag
    {
    }

    public class Element<THelper> : Tag<THelper, Element<THelper>, ElementWrapper<THelper>>, IElement, IHasTextContent
        where THelper : BootstrapHelper<THelper>
    {
        internal Element(IComponentCreator<THelper> creator, string tagName)
            : base(creator, tagName)
        {
        }
    }
}
