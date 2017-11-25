﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NationalCriminal.Search.Service.DataAccess
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="CriminalDatabase")]
	public partial class CriminalDBDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertCriminalCrimeDetail(CriminalCrimeDetail instance);
    partial void UpdateCriminalCrimeDetail(CriminalCrimeDetail instance);
    partial void DeleteCriminalCrimeDetail(CriminalCrimeDetail instance);
    partial void InsertCriminalProfile(CriminalProfile instance);
    partial void UpdateCriminalProfile(CriminalProfile instance);
    partial void DeleteCriminalProfile(CriminalProfile instance);
    #endregion
		
		public CriminalDBDataContext() : 
				base(global::NationalCriminal.Search.Service.DataAccess.Properties.Settings.Default.CriminalDatabaseConnectionString1, mappingSource)
		{
			OnCreated();
		}
		
		public CriminalDBDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public CriminalDBDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public CriminalDBDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public CriminalDBDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<CriminalCrimeDetail> CriminalCrimeDetails
		{
			get
			{
				return this.GetTable<CriminalCrimeDetail>();
			}
		}
		
		public System.Data.Linq.Table<CriminalProfile> CriminalProfiles
		{
			get
			{
				return this.GetTable<CriminalProfile>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.CriminalCrimeDetails")]
	public partial class CriminalCrimeDetail : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _crime_id;
		
		private int _criminal_id;
		
		private string _crime_type;
		
		private string _crime_description;
		
		private System.DateTime _crime_datetime;
		
		private string _crime_location;
		
		private string _crime_charges;
		
		private string _fir_no;
		
		private EntityRef<CriminalProfile> _CriminalProfile;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Oncrime_idChanging(int value);
    partial void Oncrime_idChanged();
    partial void Oncriminal_idChanging(int value);
    partial void Oncriminal_idChanged();
    partial void Oncrime_typeChanging(string value);
    partial void Oncrime_typeChanged();
    partial void Oncrime_descriptionChanging(string value);
    partial void Oncrime_descriptionChanged();
    partial void Oncrime_datetimeChanging(System.DateTime value);
    partial void Oncrime_datetimeChanged();
    partial void Oncrime_locationChanging(string value);
    partial void Oncrime_locationChanged();
    partial void Oncrime_chargesChanging(string value);
    partial void Oncrime_chargesChanged();
    partial void Onfir_noChanging(string value);
    partial void Onfir_noChanged();
    #endregion
		
		public CriminalCrimeDetail()
		{
			this._CriminalProfile = default(EntityRef<CriminalProfile>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_crime_id", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int crime_id
		{
			get
			{
				return this._crime_id;
			}
			set
			{
				if ((this._crime_id != value))
				{
					this.Oncrime_idChanging(value);
					this.SendPropertyChanging();
					this._crime_id = value;
					this.SendPropertyChanged("crime_id");
					this.Oncrime_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_criminal_id", DbType="Int NOT NULL")]
		public int criminal_id
		{
			get
			{
				return this._criminal_id;
			}
			set
			{
				if ((this._criminal_id != value))
				{
					if (this._CriminalProfile.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Oncriminal_idChanging(value);
					this.SendPropertyChanging();
					this._criminal_id = value;
					this.SendPropertyChanged("criminal_id");
					this.Oncriminal_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_crime_type", DbType="NVarChar(20) NOT NULL", CanBeNull=false)]
		public string crime_type
		{
			get
			{
				return this._crime_type;
			}
			set
			{
				if ((this._crime_type != value))
				{
					this.Oncrime_typeChanging(value);
					this.SendPropertyChanging();
					this._crime_type = value;
					this.SendPropertyChanged("crime_type");
					this.Oncrime_typeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_crime_description", DbType="NVarChar(500)")]
		public string crime_description
		{
			get
			{
				return this._crime_description;
			}
			set
			{
				if ((this._crime_description != value))
				{
					this.Oncrime_descriptionChanging(value);
					this.SendPropertyChanging();
					this._crime_description = value;
					this.SendPropertyChanged("crime_description");
					this.Oncrime_descriptionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_crime_datetime", DbType="DateTime NOT NULL")]
		public System.DateTime crime_datetime
		{
			get
			{
				return this._crime_datetime;
			}
			set
			{
				if ((this._crime_datetime != value))
				{
					this.Oncrime_datetimeChanging(value);
					this.SendPropertyChanging();
					this._crime_datetime = value;
					this.SendPropertyChanged("crime_datetime");
					this.Oncrime_datetimeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_crime_location", DbType="NVarChar(20)")]
		public string crime_location
		{
			get
			{
				return this._crime_location;
			}
			set
			{
				if ((this._crime_location != value))
				{
					this.Oncrime_locationChanging(value);
					this.SendPropertyChanging();
					this._crime_location = value;
					this.SendPropertyChanged("crime_location");
					this.Oncrime_locationChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_crime_charges", DbType="NChar(10)")]
		public string crime_charges
		{
			get
			{
				return this._crime_charges;
			}
			set
			{
				if ((this._crime_charges != value))
				{
					this.Oncrime_chargesChanging(value);
					this.SendPropertyChanging();
					this._crime_charges = value;
					this.SendPropertyChanged("crime_charges");
					this.Oncrime_chargesChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_fir_no", DbType="NChar(10) NOT NULL", CanBeNull=false)]
		public string fir_no
		{
			get
			{
				return this._fir_no;
			}
			set
			{
				if ((this._fir_no != value))
				{
					this.Onfir_noChanging(value);
					this.SendPropertyChanging();
					this._fir_no = value;
					this.SendPropertyChanged("fir_no");
					this.Onfir_noChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="CriminalProfile_CriminalCrimeDetail", Storage="_CriminalProfile", ThisKey="criminal_id", OtherKey="criminal_id", IsForeignKey=true)]
		public CriminalProfile CriminalProfile
		{
			get
			{
				return this._CriminalProfile.Entity;
			}
			set
			{
				CriminalProfile previousValue = this._CriminalProfile.Entity;
				if (((previousValue != value) 
							|| (this._CriminalProfile.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._CriminalProfile.Entity = null;
						previousValue.CriminalCrimeDetails.Remove(this);
					}
					this._CriminalProfile.Entity = value;
					if ((value != null))
					{
						value.CriminalCrimeDetails.Add(this);
						this._criminal_id = value.criminal_id;
					}
					else
					{
						this._criminal_id = default(int);
					}
					this.SendPropertyChanged("CriminalProfile");
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.CriminalProfile")]
	public partial class CriminalProfile : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _criminal_id;
		
		private string _name;
		
		private string _nickname;
		
		private System.Nullable<int> _age;
		
		private string _sex;
		
		private System.Nullable<int> _height;
		
		private System.Nullable<int> _weight;
		
		private string _nationality;
		
		private string _address;
		
		private System.Data.Linq.Binary _photo;
		
		private string _country;
		
		private string _state;
		
		private string _city;
		
		private string _ciminal_identification_marks;
		
		private EntitySet<CriminalCrimeDetail> _CriminalCrimeDetails;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Oncriminal_idChanging(int value);
    partial void Oncriminal_idChanged();
    partial void OnnameChanging(string value);
    partial void OnnameChanged();
    partial void OnnicknameChanging(string value);
    partial void OnnicknameChanged();
    partial void OnageChanging(System.Nullable<int> value);
    partial void OnageChanged();
    partial void OnsexChanging(string value);
    partial void OnsexChanged();
    partial void OnheightChanging(System.Nullable<int> value);
    partial void OnheightChanged();
    partial void OnweightChanging(System.Nullable<int> value);
    partial void OnweightChanged();
    partial void OnnationalityChanging(string value);
    partial void OnnationalityChanged();
    partial void OnaddressChanging(string value);
    partial void OnaddressChanged();
    partial void OnphotoChanging(System.Data.Linq.Binary value);
    partial void OnphotoChanged();
    partial void OncountryChanging(string value);
    partial void OncountryChanged();
    partial void OnstateChanging(string value);
    partial void OnstateChanged();
    partial void OncityChanging(string value);
    partial void OncityChanged();
    partial void Onciminal_identification_marksChanging(string value);
    partial void Onciminal_identification_marksChanged();
    #endregion
		
		public CriminalProfile()
		{
			this._CriminalCrimeDetails = new EntitySet<CriminalCrimeDetail>(new Action<CriminalCrimeDetail>(this.attach_CriminalCrimeDetails), new Action<CriminalCrimeDetail>(this.detach_CriminalCrimeDetails));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_criminal_id", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int criminal_id
		{
			get
			{
				return this._criminal_id;
			}
			set
			{
				if ((this._criminal_id != value))
				{
					this.Oncriminal_idChanging(value);
					this.SendPropertyChanging();
					this._criminal_id = value;
					this.SendPropertyChanged("criminal_id");
					this.Oncriminal_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_name", DbType="NVarChar(100)")]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_nickname", DbType="NVarChar(30)")]
		public string nickname
		{
			get
			{
				return this._nickname;
			}
			set
			{
				if ((this._nickname != value))
				{
					this.OnnicknameChanging(value);
					this.SendPropertyChanging();
					this._nickname = value;
					this.SendPropertyChanged("nickname");
					this.OnnicknameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_age", DbType="Int")]
		public System.Nullable<int> age
		{
			get
			{
				return this._age;
			}
			set
			{
				if ((this._age != value))
				{
					this.OnageChanging(value);
					this.SendPropertyChanging();
					this._age = value;
					this.SendPropertyChanged("age");
					this.OnageChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_sex", DbType="NVarChar(10)")]
		public string sex
		{
			get
			{
				return this._sex;
			}
			set
			{
				if ((this._sex != value))
				{
					this.OnsexChanging(value);
					this.SendPropertyChanging();
					this._sex = value;
					this.SendPropertyChanged("sex");
					this.OnsexChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_height", DbType="Int")]
		public System.Nullable<int> height
		{
			get
			{
				return this._height;
			}
			set
			{
				if ((this._height != value))
				{
					this.OnheightChanging(value);
					this.SendPropertyChanging();
					this._height = value;
					this.SendPropertyChanged("height");
					this.OnheightChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_weight", DbType="Int")]
		public System.Nullable<int> weight
		{
			get
			{
				return this._weight;
			}
			set
			{
				if ((this._weight != value))
				{
					this.OnweightChanging(value);
					this.SendPropertyChanging();
					this._weight = value;
					this.SendPropertyChanged("weight");
					this.OnweightChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_nationality", DbType="NVarChar(20)")]
		public string nationality
		{
			get
			{
				return this._nationality;
			}
			set
			{
				if ((this._nationality != value))
				{
					this.OnnationalityChanging(value);
					this.SendPropertyChanging();
					this._nationality = value;
					this.SendPropertyChanged("nationality");
					this.OnnationalityChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_address", DbType="NVarChar(50)")]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_photo", DbType="Image", CanBeNull=true, UpdateCheck=UpdateCheck.Never)]
		public System.Data.Linq.Binary photo
		{
			get
			{
				return this._photo;
			}
			set
			{
				if ((this._photo != value))
				{
					this.OnphotoChanging(value);
					this.SendPropertyChanging();
					this._photo = value;
					this.SendPropertyChanged("photo");
					this.OnphotoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_country", DbType="NVarChar(20)")]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_state", DbType="NVarChar(20)")]
		public string state
		{
			get
			{
				return this._state;
			}
			set
			{
				if ((this._state != value))
				{
					this.OnstateChanging(value);
					this.SendPropertyChanging();
					this._state = value;
					this.SendPropertyChanged("state");
					this.OnstateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_city", DbType="NVarChar(20)")]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ciminal_identification_marks", DbType="NVarChar(500)")]
		public string ciminal_identification_marks
		{
			get
			{
				return this._ciminal_identification_marks;
			}
			set
			{
				if ((this._ciminal_identification_marks != value))
				{
					this.Onciminal_identification_marksChanging(value);
					this.SendPropertyChanging();
					this._ciminal_identification_marks = value;
					this.SendPropertyChanged("ciminal_identification_marks");
					this.Onciminal_identification_marksChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="CriminalProfile_CriminalCrimeDetail", Storage="_CriminalCrimeDetails", ThisKey="criminal_id", OtherKey="criminal_id")]
		public EntitySet<CriminalCrimeDetail> CriminalCrimeDetails
		{
			get
			{
				return this._CriminalCrimeDetails;
			}
			set
			{
				this._CriminalCrimeDetails.Assign(value);
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
		
		private void attach_CriminalCrimeDetails(CriminalCrimeDetail entity)
		{
			this.SendPropertyChanging();
			entity.CriminalProfile = this;
		}
		
		private void detach_CriminalCrimeDetails(CriminalCrimeDetail entity)
		{
			this.SendPropertyChanging();
			entity.CriminalProfile = null;
		}
	}
}
#pragma warning restore 1591