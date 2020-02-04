﻿using System.Collections.Generic;

namespace AssetsTools.NET
{
    public class ClassDatabaseType
    {
        public int classId;
        public int baseClass;
        public ClassDatabaseFileString name;

        public List<ClassDatabaseTypeField> fields;
        public void Read(AssetsFileReader reader, int version)
        {
            classId = reader.ReadInt32();
            baseClass = reader.ReadInt32();
            name = new ClassDatabaseFileString();
            name.Read(reader);
            uint fieldCount = reader.ReadUInt32();
            fields = new List<ClassDatabaseTypeField>();
            for (int i = 0; i < fieldCount; i++)
            {
                ClassDatabaseTypeField cdtf = new ClassDatabaseTypeField();
                cdtf.Read(reader, version);
                fields.Add(cdtf);
            }
        }
        public void Write(AssetsFileWriter writer, int version)
        {
            writer.Write(classId);
            writer.Write(baseClass);
            name.Write(writer);
            writer.Write(fields.Count);
            for (int i = 0; i < fields.Count; i++)
            {
                fields[i].Write(writer, version);
            }
        }
    }
}
