//-----------------------------------------------------------------------------
// (c) 2019 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
//-----------------------------------------------------------------------------

using System;
using System.Xml.Serialization;

namespace MkvChapterGenerator.XmlObjects
{
    [Serializable()]
    [XmlType(AnonymousType = true)]
    public class ChaptersChapterAtomChapterDisplay
    {
        public string? ChapterString { get; set; }

        public string? ChapterLanguage { get; set; }
    }
}
