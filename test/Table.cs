using Linq2Oracle;
using Linq2Oracle.Expressions;
using Oracle.ManagedDataAccess.Client;

namespace Test.DataModel.Code
{
    public enum Flag
    {
        N,
        Y
    }

    [ConcurrencyCheck("UPDATE_DATE")]
    public sealed partial class N_USER : DbEntity, System.IEquatable<N_USER>
    {
        #region Methods
        public bool Equals(N_USER other)
        {
            if (other == null) return false;
            return _USER_ID == other._USER_ID;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as N_USER);
        }

        public override int GetHashCode()
        {
            return _USER_ID.GetHashCode();
        }
        #endregion
        #region AD_FLAG
        Flag _AD_FLAG;
        [Column(Size = 1, DbType = OracleDbType.Varchar2)]
        public Flag AD_FLAG
        {
            get { return _AD_FLAG; }
            set
            {
                if (_AD_FLAG != value)
                {
                    BeforeColumnChange();
                    _AD_FLAG = value;
                    NotifyPropertyChanged();
                }
            }
        }
        #endregion
        #region CREATE_DATE
        System.DateTime? _CREATE_DATE;
        [Column(Size = 11, DbType = OracleDbType.TimeStamp, IsNullable = true)]
        public System.DateTime? CREATE_DATE
        {
            get { return _CREATE_DATE; }
            set
            {
                if (_CREATE_DATE != value)
                {
                    BeforeColumnChange();
                    _CREATE_DATE = value;
                    NotifyPropertyChanged();
                }
            }
        }
        #endregion
        #region DEPT_CODE
        string _DEPT_CODE;
        [Column(Size = 4, DbType = OracleDbType.Varchar2, IsNullable = true)]
        public string DEPT_CODE
        {
            get { return _DEPT_CODE; }
            set
            {
                if (_DEPT_CODE != value)
                {
                    BeforeColumnChange();
                    _DEPT_CODE = value;
                    NotifyPropertyChanged();
                }
            }
        }
        #endregion
        #region EXPIRED_DATE
        System.DateTime? _EXPIRED_DATE;
        [Column(Size = 11, DbType = OracleDbType.TimeStamp, IsNullable = true)]
        public System.DateTime? EXPIRED_DATE
        {
            get { return _EXPIRED_DATE; }
            set
            {
                if (_EXPIRED_DATE != value)
                {
                    BeforeColumnChange();
                    _EXPIRED_DATE = value;
                    NotifyPropertyChanged();
                }
            }
        }
        #endregion
        #region LANG
        string _LANG;
        [Column(Size = 6, DbType = OracleDbType.Varchar2)]
        public string LANG
        {
            get { return _LANG; }
            set
            {
                if (_LANG != value)
                {
                    BeforeColumnChange();
                    _LANG = value;
                    NotifyPropertyChanged();
                }
            }
        }
        #endregion
        #region LOCK_FLAG
        Flag? _LOCK_FLAG;
        [Column(Size = 1, DbType = OracleDbType.Varchar2)]
        public Flag? LOCK_FLAG
        {
            get { return _LOCK_FLAG; }
            set
            {
                if (_LOCK_FLAG != value)
                {
                    BeforeColumnChange();
                    _LOCK_FLAG = value;
                    NotifyPropertyChanged();
                }
            }
        }
        #endregion
        #region PASSWORD
        string _PASSWORD;
        [Column(Size = 10, DbType = OracleDbType.Varchar2)]
        public string PASSWORD
        {
            get { return _PASSWORD; }
            set
            {
                if (_PASSWORD != value)
                {
                    BeforeColumnChange();
                    _PASSWORD = value;
                    NotifyPropertyChanged();
                }
            }
        }
        #endregion
        #region USER_ID
        string _USER_ID;
        [Column(Size = 20, DbType = OracleDbType.Varchar2, IsPrimarykey = true)]
        public string USER_ID
        {
            get { return _USER_ID; }
            set
            {
                if (_USER_ID != value)
                {
                    BeforeColumnChange();
                    _USER_ID = value;
                    NotifyPropertyChanged();
                }
            }
        }
        #endregion
        #region USER_NAME
        string _USER_NAME;
        [Column(Size = 20, DbType = OracleDbType.Varchar2)]
        public string USER_NAME
        {
            get { return _USER_NAME; }
            set
            {
                if (_USER_NAME != value)
                {
                    BeforeColumnChange();
                    _USER_NAME = value;
                    NotifyPropertyChanged();
                }
            }
        }
        #endregion
        #region VALID_FLAG
        string _VALID_FLAG;
        [Column(Size = 1, DbType = OracleDbType.Varchar2)]
        public string VALID_FLAG
        {
            get { return _VALID_FLAG; }
            set
            {
                if (_VALID_FLAG != value)
                {
                    BeforeColumnChange();
                    _VALID_FLAG = value;
                    NotifyPropertyChanged();
                }
            }
        }
        #endregion

        #region LOGIN_COUNT
        int? _LOGIN_COUNT;
        [Column(Size = 1, DbType = OracleDbType.Varchar2)]
        public int? LOGIN_COUNT
        {
            get { return _LOGIN_COUNT; }
            set
            {
                if (_LOGIN_COUNT != value)
                {
                    BeforeColumnChange();
                    _LOGIN_COUNT = value;
                    NotifyPropertyChanged();
                }
            }
        }
        #endregion
        #region AGE
        int _AGE;
        [Column(Size = 1, DbType = OracleDbType.Varchar2)]
        public int AGE
        {
            get { return _AGE; }
            set
            {
                if (_AGE != value)
                {
                    BeforeColumnChange();
                    _AGE = value;
                    NotifyPropertyChanged();
                }
            }
        }
        #endregion
        #region Query Interface
        public sealed class Query
        {
            public Enum<Flag> AD_FLAG { get; private set; }
            public DbDateTime CREATE_DATE { get; private set; }
            public DbString DEPT_CODE { get; private set; }
            public NullableDbDateTime EXPIRED_DATE { get; private set; }
            public DbString LANG { get; private set; }
            public NullableEnum<Flag> LOCK_FLAG { get; private set; }
            public DbString PASSWORD { get; private set; }
            public DbString USER_ID { get; private set; }
            public DbString USER_NAME { get; private set; }
            public Enum<Flag> VALID_FLAG { get; private set; }
            public NullableDbNumber LOGIN_COUNT { get; private set; }
            public DbNumber AGE { get; private set; }
        }
        #endregion
    }

    //public sealed partial class N_USERGROUP : DbEntity, System.IEquatable<N_USERGROUP> {
    //    #region Methods
    //    public bool Equals(N_USERGROUP other) {
    //        if (other == null) return false;
    //        return _UGROUP_ID == other._UGROUP_ID;
    //    }

    //    public override bool Equals(object obj) {
    //        return Equals(obj as N_USERGROUP);
    //    }

    //    public override int GetHashCode() {
    //        return _UGROUP_ID.GetHashCode();
    //    }
    //    #endregion
    //    #region UGROUP_ID
    //    string _UGROUP_ID;
    //    [Column(Size=20, DbType=OracleDbType.Varchar2, IsPrimarykey = true)]
    //    public string UGROUP_ID { 
    //        get{ return _UGROUP_ID; }
    //        set{
    //            if (_UGROUP_ID != value){
    //                BeforeColumnChange();
    //                _UGROUP_ID = value;   
    //                NotifyPropertyChanged();
    //            }
    //        }
    //    }
    //    #endregion
    //    #region UGROUP_NAME
    //    string _UGROUP_NAME;
    //    [Column(Size=20, DbType=OracleDbType.Varchar2, IsNullable = true)]
    //    public string UGROUP_NAME { 
    //        get{ return _UGROUP_NAME; }
    //        set{
    //            if (_UGROUP_NAME != value){
    //                BeforeColumnChange();
    //                _UGROUP_NAME = value;   
    //                NotifyPropertyChanged();
    //            }
    //        }
    //    }
    //    #endregion
    //    #region Query Interface
    //    public sealed class Query {		
    //        public String UGROUP_ID { get; private set; }
    //        public String UGROUP_NAME { get; private set; }
    //    }
    //    #endregion
    //}

    //public sealed partial class N_USERGROUP_R : DbEntity, System.IEquatable<N_USERGROUP_R> {
    //    #region Methods
    //    public bool Equals(N_USERGROUP_R other) {
    //        if (other == null) return false;
    //        return _UGROUP_ID == other._UGROUP_ID && _USER_ID == other._USER_ID;
    //    }

    //    public override bool Equals(object obj) {
    //        return Equals(obj as N_USERGROUP_R);
    //    }

    //    public override int GetHashCode() {
    //        return _UGROUP_ID.GetHashCode() ^ _USER_ID.GetHashCode();
    //    }
    //    #endregion
    //    #region UGROUP_ID
    //    string _UGROUP_ID;
    //    [Column(Size=20, DbType=OracleDbType.Varchar2, IsPrimarykey = true)]
    //    public string UGROUP_ID { 
    //        get{ return _UGROUP_ID; }
    //        set{
    //            if (_UGROUP_ID != value){
    //                BeforeColumnChange();
    //                _UGROUP_ID = value;   
    //                NotifyPropertyChanged();
    //            }
    //        }
    //    }
    //    #endregion
    //    #region USER_ID
    //    string _USER_ID;
    //    [Column(Size=20, DbType=OracleDbType.Varchar2, IsPrimarykey = true)]
    //    public string USER_ID { 
    //        get{ return _USER_ID; }
    //        set{
    //            if (_USER_ID != value){
    //                BeforeColumnChange();
    //                _USER_ID = value;   
    //                NotifyPropertyChanged();
    //            }
    //        }
    //    }
    //    #endregion
    //    #region Query Interface
    //    public sealed class Query {		
    //        public String UGROUP_ID { get; private set; }
    //        public String USER_ID { get; private set; }
    //    }
    //    #endregion
    //}
}
