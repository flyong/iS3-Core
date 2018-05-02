﻿using System.Runtime.Serialization;
using System.Data;
using System.Collections.Generic;
using System.Windows;

//using iS3.Core.Shape;
//using iS3.Core.Serialization;
using System.ComponentModel.DataAnnotations;

namespace iS3.Core
{
    #region Copyright Notice
    //************************  Notice  **********************************
    //** This file is part of iS3
    //**
    //** Copyright (c) 2015 Tongji University iS3 Team. All rights reserved.
    //**
    //** This library is free software; you can redistribute it and/or
    //** modify it under the terms of the GNU Lesser General Public
    //** License as published by the Free Software Foundation; either
    //** version 3 of the License, or (at your option) any later version.
    //**
    //** This library is distributed in the hope that it will be useful,
    //** but WITHOUT ANY WARRANTY; without even the implied warranty of
    //** MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
    //** Lesser General Public License for more details.
    //**
    //** In addition, as a special exception,  that plugins developed for iS3,
    //** are allowed to remain closed sourced and can be distributed under any license .
    //** These rights are included in the file LGPL_EXCEPTION.txt in this package.
    //**
    //**************************************************************************
    #endregion

    // Summary:
    //     DGObject: digital object base class.
    // Remarks:
    //     (1) DGObject usually corresponds to a data row of a table,
    //         see _rawData member variable.
    //     (2) DGObject(s) are stored in the DGObjects class as a collection.
    //     (3) DGObject must have unique id and unique name in a group.
    //     (4) DGObject has a key default to its name, subclass can override
    //         the key.
    //     (5) If DGObject is readed from ArcGIS geodatabase, it can handle
    //         shape objects, see ShapeObject for more info.
    //
    [DataContract]
    public class DGObject
    {
        protected int _id;
        protected string _name;
        protected string _fullname;
        protected string _desc;

        // raw data from database
        protected DataRow _rawData;

        //// shape for the object
        //protected ShapeObject _shp;

        //// parent of the object
        //protected DGObjects _parent;

        // return a string that will be used as the unique key to this object
        public virtual string key
        {
            get { return _name; }
        }

        //public DGObjects parent
        //{
        //    get { return _parent; }
        //    set { _parent = value; }
        //}

        // constructor
        public DGObject()
        {
        }
        public DGObject(DataRow rawData)
        {
            _rawData = rawData;
        }

        [DataMember]
        [Key]
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        [DataMember]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        [DataMember]
        public string FullName
        {
            get { return _fullname; }
            set { _fullname = value; }
        }
        [DataMember]
        public string Description
        {
            get { return _desc; }
            set { _desc = value; }
        }
        //[DataMember]
        //public ShapeObject Shape
        //{
        //    get { return _shp; }
        //    set { _shp = value; }
        //}

        public DataRow RawData
        {
            get { return _rawData; }
        }

        // Summary:
        //    Load objects from database
        //public virtual bool LoadObjs(DGObjects objs)
        //{
        //    DGObjectLoader loader2 = new DGObjectLoader();
        //    bool success = loader2.Load(objs);
        //    return success;
        //}

        public override string ToString()
        {
            return string.Format("ID={0}, Name={1}", ID, Name);
        }

        // Summary:
        //    Table views of the objects.
        // Remarks:
        //    Apart from normal properties (i.e., data members), a object may
        //    have sub-properties.
        //    Take a borehole as an example, it usually contains strata data records
        //    which is in another data table.
        //    This function returns the List<DataView> of given object list.
        public virtual List<DataView> tableViews(IEnumerable<DGObject> objs)
        {
            List<DataView> dataViews = new List<DataView>();
            //DataTable table = parent.rawDataSet.Tables[0];
            //string filter = idFilter(objs);
            //DataView view = new DataView(table, filter, "[ID]", DataViewRowState.CurrentRows);
            //dataViews.Add(view);
            return dataViews;
        }

        string idFilter(IEnumerable<DGObject> objs)
        {
            string sql = "ID in (";
            foreach (var obj in objs)
            {
                sql += obj.ID.ToString();
                sql += ",";
            }
            sql += ")";
            return sql;
        }

        // Summary:
        //     Chart views of the objects
        // Remarks:
        //     
        public virtual List<FrameworkElement> chartViews(
            IEnumerable<DGObject> objs, double width, double height)
        {
            return null;
        }

    }

    // DGEntity will be removed soon.
    // Use DGObject instead.
    public class DGEntity : DGObject
    {
    }
}
