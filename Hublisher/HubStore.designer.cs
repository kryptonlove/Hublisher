﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18010
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hublisher
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="hublisher")]
	public partial class HubStoreDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void Insertbrand(brand instance);
    partial void Updatebrand(brand instance);
    partial void Deletebrand(brand instance);
    partial void Insertuser(user instance);
    partial void Updateuser(user instance);
    partial void Deleteuser(user instance);
    partial void Insertestablishment(establishment instance);
    partial void Updateestablishment(establishment instance);
    partial void Deleteestablishment(establishment instance);
    partial void Insertestablishment_brand(establishment_brand instance);
    partial void Updateestablishment_brand(establishment_brand instance);
    partial void Deleteestablishment_brand(establishment_brand instance);
    #endregion
		
		public HubStoreDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["hublisherConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public HubStoreDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public HubStoreDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public HubStoreDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public HubStoreDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<brand> brands
		{
			get
			{
				return this.GetTable<brand>();
			}
		}
		
		public System.Data.Linq.Table<user> users
		{
			get
			{
				return this.GetTable<user>();
			}
		}
		
		public System.Data.Linq.Table<establishment> establishments
		{
			get
			{
				return this.GetTable<establishment>();
			}
		}
		
		public System.Data.Linq.Table<establishment_brand> establishment_brands
		{
			get
			{
				return this.GetTable<establishment_brand>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.brands")]
	public partial class brand : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private string _name;
		
		private string _country;
		
		private string _maker;
		
		private string _volume;
		
		private string _description;
		
		private string _type;
		
		private System.Nullable<int> _createdby;
		
		private System.Nullable<int> _updatedby;
		
		private System.Nullable<System.DateTime> _updated;
		
		private System.Nullable<System.DateTime> _created;
		
		private System.Nullable<bool> _deleted;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnnameChanging(string value);
    partial void OnnameChanged();
    partial void OncountryChanging(string value);
    partial void OncountryChanged();
    partial void OnmakerChanging(string value);
    partial void OnmakerChanged();
    partial void OnvolumeChanging(string value);
    partial void OnvolumeChanged();
    partial void OndescriptionChanging(string value);
    partial void OndescriptionChanged();
    partial void OntypeChanging(string value);
    partial void OntypeChanged();
    partial void OncreatedbyChanging(System.Nullable<int> value);
    partial void OncreatedbyChanged();
    partial void OnupdatedbyChanging(System.Nullable<int> value);
    partial void OnupdatedbyChanged();
    partial void OnupdatedChanging(System.Nullable<System.DateTime> value);
    partial void OnupdatedChanged();
    partial void OncreatedChanging(System.Nullable<System.DateTime> value);
    partial void OncreatedChanged();
    partial void OndeletedChanging(System.Nullable<bool> value);
    partial void OndeletedChanged();
    #endregion
		
		public brand()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_name", DbType="NVarChar(256)")]
		public string name
		{
			get
			{
				return this._name;
			}
			set
			{
				if ((this._name != value))
				{
					this.OnnameChanging(value);
					this.SendPropertyChanging();
					this._name = value;
					this.SendPropertyChanged("name");
					this.OnnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_country", DbType="NVarChar(64)")]
		public string country
		{
			get
			{
				return this._country;
			}
			set
			{
				if ((this._country != value))
				{
					this.OncountryChanging(value);
					this.SendPropertyChanging();
					this._country = value;
					this.SendPropertyChanged("country");
					this.OncountryChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_maker", DbType="NVarChar(64)")]
		public string maker
		{
			get
			{
				return this._maker;
			}
			set
			{
				if ((this._maker != value))
				{
					this.OnmakerChanging(value);
					this.SendPropertyChanging();
					this._maker = value;
					this.SendPropertyChanged("maker");
					this.OnmakerChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_volume", DbType="NVarChar(32)")]
		public string volume
		{
			get
			{
				return this._volume;
			}
			set
			{
				if ((this._volume != value))
				{
					this.OnvolumeChanging(value);
					this.SendPropertyChanging();
					this._volume = value;
					this.SendPropertyChanged("volume");
					this.OnvolumeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_description", DbType="NVarChar(400)")]
		public string description
		{
			get
			{
				return this._description;
			}
			set
			{
				if ((this._description != value))
				{
					this.OndescriptionChanging(value);
					this.SendPropertyChanging();
					this._description = value;
					this.SendPropertyChanged("description");
					this.OndescriptionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_type", DbType="NVarChar(100)")]
		public string type
		{
			get
			{
				return this._type;
			}
			set
			{
				if ((this._type != value))
				{
					this.OntypeChanging(value);
					this.SendPropertyChanging();
					this._type = value;
					this.SendPropertyChanged("type");
					this.OntypeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_createdby", DbType="Int")]
		public System.Nullable<int> createdby
		{
			get
			{
				return this._createdby;
			}
			set
			{
				if ((this._createdby != value))
				{
					this.OncreatedbyChanging(value);
					this.SendPropertyChanging();
					this._createdby = value;
					this.SendPropertyChanged("createdby");
					this.OncreatedbyChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_updatedby", DbType="Int")]
		public System.Nullable<int> updatedby
		{
			get
			{
				return this._updatedby;
			}
			set
			{
				if ((this._updatedby != value))
				{
					this.OnupdatedbyChanging(value);
					this.SendPropertyChanging();
					this._updatedby = value;
					this.SendPropertyChanged("updatedby");
					this.OnupdatedbyChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_updated", DbType="DateTime")]
		public System.Nullable<System.DateTime> updated
		{
			get
			{
				return this._updated;
			}
			set
			{
				if ((this._updated != value))
				{
					this.OnupdatedChanging(value);
					this.SendPropertyChanging();
					this._updated = value;
					this.SendPropertyChanged("updated");
					this.OnupdatedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_created", DbType="DateTime", IsDbGenerated=true)]
		public System.Nullable<System.DateTime> created
		{
			get
			{
				return this._created;
			}
			set
			{
				if ((this._created != value))
				{
					this.OncreatedChanging(value);
					this.SendPropertyChanging();
					this._created = value;
					this.SendPropertyChanged("created");
					this.OncreatedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_deleted", DbType="Bit")]
		public System.Nullable<bool> deleted
		{
			get
			{
				return this._deleted;
			}
			set
			{
				if ((this._deleted != value))
				{
					this.OndeletedChanging(value);
					this.SendPropertyChanging();
					this._deleted = value;
					this.SendPropertyChanged("deleted");
					this.OndeletedChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.users")]
	public partial class user : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private System.DateTime _created;
		
		private System.Nullable<System.DateTime> _updated;
		
		private System.Nullable<int> _logins;
		
		private string _email;
		
		private string _alias;
		
		private string _password;
		
		private bool _administrator;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OncreatedChanging(System.DateTime value);
    partial void OncreatedChanged();
    partial void OnupdatedChanging(System.Nullable<System.DateTime> value);
    partial void OnupdatedChanged();
    partial void OnloginsChanging(System.Nullable<int> value);
    partial void OnloginsChanged();
    partial void OnemailChanging(string value);
    partial void OnemailChanged();
    partial void OnaliasChanging(string value);
    partial void OnaliasChanged();
    partial void OnpasswordChanging(string value);
    partial void OnpasswordChanged();
    partial void OnadministratorChanging(bool value);
    partial void OnadministratorChanged();
    #endregion
		
		public user()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_created", DbType="DateTime NOT NULL", IsDbGenerated=true)]
		public System.DateTime created
		{
			get
			{
				return this._created;
			}
			set
			{
				if ((this._created != value))
				{
					this.OncreatedChanging(value);
					this.SendPropertyChanging();
					this._created = value;
					this.SendPropertyChanged("created");
					this.OncreatedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_updated", DbType="DateTime")]
		public System.Nullable<System.DateTime> updated
		{
			get
			{
				return this._updated;
			}
			set
			{
				if ((this._updated != value))
				{
					this.OnupdatedChanging(value);
					this.SendPropertyChanging();
					this._updated = value;
					this.SendPropertyChanged("updated");
					this.OnupdatedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_logins", DbType="Int")]
		public System.Nullable<int> logins
		{
			get
			{
				return this._logins;
			}
			set
			{
				if ((this._logins != value))
				{
					this.OnloginsChanging(value);
					this.SendPropertyChanging();
					this._logins = value;
					this.SendPropertyChanged("logins");
					this.OnloginsChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_email", DbType="VarChar(128) NOT NULL", CanBeNull=false)]
		public string email
		{
			get
			{
				return this._email;
			}
			set
			{
				if ((this._email != value))
				{
					this.OnemailChanging(value);
					this.SendPropertyChanging();
					this._email = value;
					this.SendPropertyChanged("email");
					this.OnemailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_alias", DbType="VarChar(42)")]
		public string alias
		{
			get
			{
				return this._alias;
			}
			set
			{
				if ((this._alias != value))
				{
					this.OnaliasChanging(value);
					this.SendPropertyChanging();
					this._alias = value;
					this.SendPropertyChanged("alias");
					this.OnaliasChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_password", DbType="VarChar(512) NOT NULL", CanBeNull=false)]
		public string password
		{
			get
			{
				return this._password;
			}
			set
			{
				if ((this._password != value))
				{
					this.OnpasswordChanging(value);
					this.SendPropertyChanging();
					this._password = value;
					this.SendPropertyChanged("password");
					this.OnpasswordChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_administrator", DbType="Bit NOT NULL")]
		public bool administrator
		{
			get
			{
				return this._administrator;
			}
			set
			{
				if ((this._administrator != value))
				{
					this.OnadministratorChanging(value);
					this.SendPropertyChanging();
					this._administrator = value;
					this.SendPropertyChanged("administrator");
					this.OnadministratorChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.establishment")]
	public partial class establishment : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private string _name;
		
		private string _address;
		
		private string _country;
		
		private string _city;
		
		private string _maplink;
		
		private string _borough;
		
		private string _type;
		
		private System.Nullable<int> _userid;
		
		private System.Nullable<bool> _deleted;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnnameChanging(string value);
    partial void OnnameChanged();
    partial void OnaddressChanging(string value);
    partial void OnaddressChanged();
    partial void OncountryChanging(string value);
    partial void OncountryChanged();
    partial void OncityChanging(string value);
    partial void OncityChanged();
    partial void OnmaplinkChanging(string value);
    partial void OnmaplinkChanged();
    partial void OnboroughChanging(string value);
    partial void OnboroughChanged();
    partial void OntypeChanging(string value);
    partial void OntypeChanged();
    partial void OnuseridChanging(System.Nullable<int> value);
    partial void OnuseridChanged();
    partial void OndeletedChanging(System.Nullable<bool> value);
    partial void OndeletedChanged();
    #endregion
		
		public establishment()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_name", DbType="NVarChar(64) NOT NULL", CanBeNull=false)]
		public string name
		{
			get
			{
				return this._name;
			}
			set
			{
				if ((this._name != value))
				{
					this.OnnameChanging(value);
					this.SendPropertyChanging();
					this._name = value;
					this.SendPropertyChanged("name");
					this.OnnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_address", DbType="NVarChar(256)")]
		public string address
		{
			get
			{
				return this._address;
			}
			set
			{
				if ((this._address != value))
				{
					this.OnaddressChanging(value);
					this.SendPropertyChanging();
					this._address = value;
					this.SendPropertyChanged("address");
					this.OnaddressChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_country", DbType="NVarChar(64) NOT NULL", CanBeNull=false)]
		public string country
		{
			get
			{
				return this._country;
			}
			set
			{
				if ((this._country != value))
				{
					this.OncountryChanging(value);
					this.SendPropertyChanging();
					this._country = value;
					this.SendPropertyChanged("country");
					this.OncountryChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_city", DbType="NVarChar(64) NOT NULL", CanBeNull=false)]
		public string city
		{
			get
			{
				return this._city;
			}
			set
			{
				if ((this._city != value))
				{
					this.OncityChanging(value);
					this.SendPropertyChanging();
					this._city = value;
					this.SendPropertyChanged("city");
					this.OncityChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_maplink", DbType="NVarChar(1024)")]
		public string maplink
		{
			get
			{
				return this._maplink;
			}
			set
			{
				if ((this._maplink != value))
				{
					this.OnmaplinkChanging(value);
					this.SendPropertyChanging();
					this._maplink = value;
					this.SendPropertyChanged("maplink");
					this.OnmaplinkChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_borough", DbType="NVarChar(64)")]
		public string borough
		{
			get
			{
				return this._borough;
			}
			set
			{
				if ((this._borough != value))
				{
					this.OnboroughChanging(value);
					this.SendPropertyChanging();
					this._borough = value;
					this.SendPropertyChanged("borough");
					this.OnboroughChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_type", DbType="NVarChar(50)")]
		public string type
		{
			get
			{
				return this._type;
			}
			set
			{
				if ((this._type != value))
				{
					this.OntypeChanging(value);
					this.SendPropertyChanging();
					this._type = value;
					this.SendPropertyChanged("type");
					this.OntypeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_userid", DbType="Int")]
		public System.Nullable<int> userid
		{
			get
			{
				return this._userid;
			}
			set
			{
				if ((this._userid != value))
				{
					this.OnuseridChanging(value);
					this.SendPropertyChanging();
					this._userid = value;
					this.SendPropertyChanged("userid");
					this.OnuseridChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_deleted", DbType="Bit")]
		public System.Nullable<bool> deleted
		{
			get
			{
				return this._deleted;
			}
			set
			{
				if ((this._deleted != value))
				{
					this.OndeletedChanging(value);
					this.SendPropertyChanging();
					this._deleted = value;
					this.SendPropertyChanged("deleted");
					this.OndeletedChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.establishment_brands")]
	public partial class establishment_brand : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private int _establishment_id;
		
		private int _brand_id;
		
		private string _size;
		
		private string _price;
		
		private System.Nullable<int> _updatedby;
		
		private System.Nullable<int> _createdby;
		
		private System.Nullable<bool> _deleted;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void Onestablishment_idChanging(int value);
    partial void Onestablishment_idChanged();
    partial void Onbrand_idChanging(int value);
    partial void Onbrand_idChanged();
    partial void OnsizeChanging(string value);
    partial void OnsizeChanged();
    partial void OnpriceChanging(string value);
    partial void OnpriceChanged();
    partial void OnupdatedbyChanging(System.Nullable<int> value);
    partial void OnupdatedbyChanged();
    partial void OncreatedbyChanging(System.Nullable<int> value);
    partial void OncreatedbyChanged();
    partial void OndeletedChanging(System.Nullable<bool> value);
    partial void OndeletedChanged();
    #endregion
		
		public establishment_brand()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_establishment_id", DbType="Int NOT NULL")]
		public int establishment_id
		{
			get
			{
				return this._establishment_id;
			}
			set
			{
				if ((this._establishment_id != value))
				{
					this.Onestablishment_idChanging(value);
					this.SendPropertyChanging();
					this._establishment_id = value;
					this.SendPropertyChanged("establishment_id");
					this.Onestablishment_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_brand_id", DbType="Int NOT NULL")]
		public int brand_id
		{
			get
			{
				return this._brand_id;
			}
			set
			{
				if ((this._brand_id != value))
				{
					this.Onbrand_idChanging(value);
					this.SendPropertyChanging();
					this._brand_id = value;
					this.SendPropertyChanged("brand_id");
					this.Onbrand_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_size", DbType="NVarChar(100)")]
		public string size
		{
			get
			{
				return this._size;
			}
			set
			{
				if ((this._size != value))
				{
					this.OnsizeChanging(value);
					this.SendPropertyChanging();
					this._size = value;
					this.SendPropertyChanged("size");
					this.OnsizeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_price", DbType="NVarChar(4)")]
		public string price
		{
			get
			{
				return this._price;
			}
			set
			{
				if ((this._price != value))
				{
					this.OnpriceChanging(value);
					this.SendPropertyChanging();
					this._price = value;
					this.SendPropertyChanged("price");
					this.OnpriceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_updatedby", DbType="Int")]
		public System.Nullable<int> updatedby
		{
			get
			{
				return this._updatedby;
			}
			set
			{
				if ((this._updatedby != value))
				{
					this.OnupdatedbyChanging(value);
					this.SendPropertyChanging();
					this._updatedby = value;
					this.SendPropertyChanged("updatedby");
					this.OnupdatedbyChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_createdby", DbType="Int")]
		public System.Nullable<int> createdby
		{
			get
			{
				return this._createdby;
			}
			set
			{
				if ((this._createdby != value))
				{
					this.OncreatedbyChanging(value);
					this.SendPropertyChanging();
					this._createdby = value;
					this.SendPropertyChanged("createdby");
					this.OncreatedbyChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_deleted", DbType="Bit")]
		public System.Nullable<bool> deleted
		{
			get
			{
				return this._deleted;
			}
			set
			{
				if ((this._deleted != value))
				{
					this.OndeletedChanging(value);
					this.SendPropertyChanging();
					this._deleted = value;
					this.SendPropertyChanged("deleted");
					this.OndeletedChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
