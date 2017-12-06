﻿using System;

using KenticoCloud.ContentManagement.Models.Identifiers;

namespace KenticoCloud.ContentManagement.Models.Items
{
    public sealed class SitemapNodeIdentifier : IdentifierWithCodename<SitemapNodeIdentifier>
    {
        [Obsolete("For internal purposes. Use static method SitemapNodeIdentifier.ByXYZ instead.")]
        public SitemapNodeIdentifier() { }
    }
}
