namespace Uania.Tools.Repository.Entities
{
    public class UserGroupActivity : BaseEntity
    {
        public Guid UserId { get; set; } = Guid.Empty;

        public string Title { get; set; } = string.Empty;


        public string ActivityContent { get; set; } = string.Empty;

        /// <summary>
        /// 线上/线下
        /// 1=线上 2=线下 3=线下+线上直播活动
        /// </summary>

        public int ActivityType { get; set; } = 0;

        /// <summary>
        /// 
        /// </summary>
        public string Summary { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string ActivityCity { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public int ActivityCityId { get; set; } = 0;

        /// <summary>
        /// 
        /// </summary>
        public DateTime CTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime UTime { get; set; }

        /// <summary>
        /// 
        /// </summary>

        public bool IsDelete { get; set; } = false;

        /// <summary>
        /// 活动开始时间
        /// </summary>
        public DateTime BeginTime { get; set; }

        /// <summary>
        ///活动结束时间
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// 0 隐藏
        /// 1 显示
        /// </summary>
        public int State { get; set; } = 0;
        /// <summary>
        /// 列表页图片
        /// </summary>
        public string BannerList { get; set; } = string.Empty;
        /// <summary>
        /// 列表页图片
        /// </summary>
        public string BannerInfo { get; set; } = string.Empty;

    }
}