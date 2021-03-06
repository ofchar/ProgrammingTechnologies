#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.42000
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Data
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="ptdb")]
	public partial class DataClasses1DataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void Insertuser(user instance);
    partial void Updateuser(user instance);
    partial void Deleteuser(user instance);
    partial void Insertcatalog(catalog instance);
    partial void Updatecatalog(catalog instance);
    partial void Deletecatalog(catalog instance);
    partial void Insertevent(@event instance);
    partial void Updateevent(@event instance);
    partial void Deleteevent(@event instance);
    #endregion
		
		public DataClasses1DataContext() : 
				base(global::Data.Properties.Settings.Default.ptdbConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<user> users
		{
			get
			{
				return this.GetTable<user>();
			}
		}
		
		public System.Data.Linq.Table<catalog> catalogs
		{
			get
			{
				return this.GetTable<catalog>();
			}
		}
		
		public System.Data.Linq.Table<@event> @event
		{
			get
			{
				return this.GetTable<@event>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.users")]
	public partial class user : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _user_id;
		
		private string _user_first_name;
		
		private string _user_last_name;
		
		private EntitySet<@event> _event;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Onuser_idChanging(int value);
    partial void Onuser_idChanged();
    partial void Onuser_first_nameChanging(string value);
    partial void Onuser_first_nameChanged();
    partial void Onuser_last_nameChanging(string value);
    partial void Onuser_last_nameChanged();
    #endregion
		
		public user()
		{
			this._event = new EntitySet<@event>(new Action<@event>(this.attach_event), new Action<@event>(this.detach_event));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_user_id", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int user_id
		{
			get
			{
				return this._user_id;
			}
			set
			{
				if ((this._user_id != value))
				{
					this.Onuser_idChanging(value);
					this.SendPropertyChanging();
					this._user_id = value;
					this.SendPropertyChanged("user_id");
					this.Onuser_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_user_first_name", DbType="VarChar(50)")]
		public string user_first_name
		{
			get
			{
				return this._user_first_name;
			}
			set
			{
				if ((this._user_first_name != value))
				{
					this.Onuser_first_nameChanging(value);
					this.SendPropertyChanging();
					this._user_first_name = value;
					this.SendPropertyChanged("user_first_name");
					this.Onuser_first_nameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_user_last_name", DbType="VarChar(50)")]
		public string user_last_name
		{
			get
			{
				return this._user_last_name;
			}
			set
			{
				if ((this._user_last_name != value))
				{
					this.Onuser_last_nameChanging(value);
					this.SendPropertyChanging();
					this._user_last_name = value;
					this.SendPropertyChanged("user_last_name");
					this.Onuser_last_nameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="user_event", Storage="_event", ThisKey="user_id", OtherKey="user_id")]
		public EntitySet<@event> @event
		{
			get
			{
				return this._event;
			}
			set
			{
				this._event.Assign(value);
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
		
		private void attach_event(@event entity)
		{
			this.SendPropertyChanging();
			entity.user = this;
		}
		
		private void detach_event(@event entity)
		{
			this.SendPropertyChanging();
			entity.user = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.catalogs")]
	public partial class catalog : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _catalog_id;
		
		private string _catalog_name;
		
		private string _catalog_genus;
		
		private System.Nullable<int> _catalog_price;
		
		private System.Nullable<int> _catalog_quantity;
		
		private EntitySet<@event> _event;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Oncatalog_idChanging(int value);
    partial void Oncatalog_idChanged();
    partial void Oncatalog_nameChanging(string value);
    partial void Oncatalog_nameChanged();
    partial void Oncatalog_genusChanging(string value);
    partial void Oncatalog_genusChanged();
    partial void Oncatalog_priceChanging(System.Nullable<int> value);
    partial void Oncatalog_priceChanged();
    partial void Oncatalog_quantityChanging(System.Nullable<int> value);
    partial void Oncatalog_quantityChanged();
    #endregion
		
		public catalog()
		{
			this._event = new EntitySet<@event>(new Action<@event>(this.attach_event), new Action<@event>(this.detach_event));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_catalog_id", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int catalog_id
		{
			get
			{
				return this._catalog_id;
			}
			set
			{
				if ((this._catalog_id != value))
				{
					this.Oncatalog_idChanging(value);
					this.SendPropertyChanging();
					this._catalog_id = value;
					this.SendPropertyChanged("catalog_id");
					this.Oncatalog_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_catalog_name", DbType="VarChar(50)")]
		public string catalog_name
		{
			get
			{
				return this._catalog_name;
			}
			set
			{
				if ((this._catalog_name != value))
				{
					this.Oncatalog_nameChanging(value);
					this.SendPropertyChanging();
					this._catalog_name = value;
					this.SendPropertyChanged("catalog_name");
					this.Oncatalog_nameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_catalog_genus", DbType="VarChar(50)")]
		public string catalog_genus
		{
			get
			{
				return this._catalog_genus;
			}
			set
			{
				if ((this._catalog_genus != value))
				{
					this.Oncatalog_genusChanging(value);
					this.SendPropertyChanging();
					this._catalog_genus = value;
					this.SendPropertyChanged("catalog_genus");
					this.Oncatalog_genusChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_catalog_price", DbType="Int")]
		public System.Nullable<int> catalog_price
		{
			get
			{
				return this._catalog_price;
			}
			set
			{
				if ((this._catalog_price != value))
				{
					this.Oncatalog_priceChanging(value);
					this.SendPropertyChanging();
					this._catalog_price = value;
					this.SendPropertyChanged("catalog_price");
					this.Oncatalog_priceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_catalog_quantity", DbType="Int")]
		public System.Nullable<int> catalog_quantity
		{
			get
			{
				return this._catalog_quantity;
			}
			set
			{
				if ((this._catalog_quantity != value))
				{
					this.Oncatalog_quantityChanging(value);
					this.SendPropertyChanging();
					this._catalog_quantity = value;
					this.SendPropertyChanged("catalog_quantity");
					this.Oncatalog_quantityChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="catalog_event", Storage="_event", ThisKey="catalog_id", OtherKey="catalog_id")]
		public EntitySet<@event> @event
		{
			get
			{
				return this._event;
			}
			set
			{
				this._event.Assign(value);
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
		
		private void attach_event(@event entity)
		{
			this.SendPropertyChanging();
			entity.catalog = this;
		}
		
		private void detach_event(@event entity)
		{
			this.SendPropertyChanging();
			entity.catalog = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.events")]
	public partial class @event : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _event_id;
		
		private System.DateTime _event_timestamp;
		
		private bool _event_is_stocking;
		
		private int _event_amount;
		
		private int _catalog_id;
		
		private int _user_id;
		
		private EntityRef<catalog> _catalog;
		
		private EntityRef<user> _user;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Onevent_idChanging(int value);
    partial void Onevent_idChanged();
    partial void Onevent_timestampChanging(System.DateTime value);
    partial void Onevent_timestampChanged();
    partial void Onevent_is_stockingChanging(bool value);
    partial void Onevent_is_stockingChanged();
    partial void Onevent_amountChanging(int value);
    partial void Onevent_amountChanged();
    partial void Oncatalog_idChanging(int value);
    partial void Oncatalog_idChanged();
    partial void Onuser_idChanging(int value);
    partial void Onuser_idChanged();
    #endregion
		
		public @event()
		{
			this._catalog = default(EntityRef<catalog>);
			this._user = default(EntityRef<user>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_event_id", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int event_id
		{
			get
			{
				return this._event_id;
			}
			set
			{
				if ((this._event_id != value))
				{
					this.Onevent_idChanging(value);
					this.SendPropertyChanging();
					this._event_id = value;
					this.SendPropertyChanged("event_id");
					this.Onevent_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_event_timestamp", DbType="Date NOT NULL")]
		public System.DateTime event_timestamp
		{
			get
			{
				return this._event_timestamp;
			}
			set
			{
				if ((this._event_timestamp != value))
				{
					this.Onevent_timestampChanging(value);
					this.SendPropertyChanging();
					this._event_timestamp = value;
					this.SendPropertyChanged("event_timestamp");
					this.Onevent_timestampChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_event_is_stocking", DbType="Bit NOT NULL")]
		public bool event_is_stocking
		{
			get
			{
				return this._event_is_stocking;
			}
			set
			{
				if ((this._event_is_stocking != value))
				{
					this.Onevent_is_stockingChanging(value);
					this.SendPropertyChanging();
					this._event_is_stocking = value;
					this.SendPropertyChanged("event_is_stocking");
					this.Onevent_is_stockingChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_event_amount", DbType="Int NOT NULL")]
		public int event_amount
		{
			get
			{
				return this._event_amount;
			}
			set
			{
				if ((this._event_amount != value))
				{
					this.Onevent_amountChanging(value);
					this.SendPropertyChanging();
					this._event_amount = value;
					this.SendPropertyChanged("event_amount");
					this.Onevent_amountChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_catalog_id", DbType="Int NOT NULL")]
		public int catalog_id
		{
			get
			{
				return this._catalog_id;
			}
			set
			{
				if ((this._catalog_id != value))
				{
					if (this._catalog.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Oncatalog_idChanging(value);
					this.SendPropertyChanging();
					this._catalog_id = value;
					this.SendPropertyChanged("catalog_id");
					this.Oncatalog_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_user_id", DbType="Int NOT NULL")]
		public int user_id
		{
			get
			{
				return this._user_id;
			}
			set
			{
				if ((this._user_id != value))
				{
					if (this._user.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Onuser_idChanging(value);
					this.SendPropertyChanging();
					this._user_id = value;
					this.SendPropertyChanged("user_id");
					this.Onuser_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="catalog_event", Storage="_catalog", ThisKey="catalog_id", OtherKey="catalog_id", IsForeignKey=true)]
		public catalog catalog
		{
			get
			{
				return this._catalog.Entity;
			}
			set
			{
				catalog previousValue = this._catalog.Entity;
				if (((previousValue != value) 
							|| (this._catalog.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._catalog.Entity = null;
						previousValue.@event.Remove(this);
					}
					this._catalog.Entity = value;
					if ((value != null))
					{
						value.@event.Add(this);
						this._catalog_id = value.catalog_id;
					}
					else
					{
						this._catalog_id = default(int);
					}
					this.SendPropertyChanged("catalog");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="user_event", Storage="_user", ThisKey="user_id", OtherKey="user_id", IsForeignKey=true)]
		public user user
		{
			get
			{
				return this._user.Entity;
			}
			set
			{
				user previousValue = this._user.Entity;
				if (((previousValue != value) 
							|| (this._user.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._user.Entity = null;
						previousValue.@event.Remove(this);
					}
					this._user.Entity = value;
					if ((value != null))
					{
						value.@event.Add(this);
						this._user_id = value.user_id;
					}
					else
					{
						this._user_id = default(int);
					}
					this.SendPropertyChanged("user");
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
