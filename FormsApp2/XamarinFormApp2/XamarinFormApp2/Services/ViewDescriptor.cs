using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinFormApp2.Services
{
    using XamarinFormApp2.Commons;
    using XamarinFormApp2.Interfaces;

    public class ViewDescriptor : IViewDescriptor
    {
        /// <summary>
        /// The view type.
        /// </summary>
        private readonly PageType pageType;

        /// <summary>
        /// The URI.
        /// </summary>
        private readonly ViewArgs viewArgs;

        public ViewDescriptor(PageType pageType, ViewArgs viewArgs = null)
        {
            this.pageType = pageType;
            this.viewArgs = viewArgs;
        }

        /// <summary>
        /// Gets the type of the view.
        /// </summary>
        /// <value>The type of the view.</value>
        public PageType PageType
        {
            get
            {
                return this.pageType;
            }
        }

        /// <summary>
        /// Gets the URI.
        /// </summary>
        /// <value>The URI.</value>
        public ViewArgs ViewArgs
        {
            get
            {
                return this.viewArgs;
            }
        }
    }
}
