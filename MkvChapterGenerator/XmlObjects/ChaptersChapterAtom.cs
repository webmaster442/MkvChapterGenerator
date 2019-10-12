//-----------------------------------------------------------------------------
// (c) 2019 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
//-----------------------------------------------------------------------------

using System;
using System.Xml.Serialization;

namespace MkvChapterGenerator.XmlObjects
{
    [Serializable]
    [XmlType(AnonymousType = true)]
    public class ChaptersChapterAtom
    {
        public string? ChapterTimeStart { get; set; }

        public ChaptersChapterAtomChapterDisplay? ChapterDisplay { get; set; }
    }

}
