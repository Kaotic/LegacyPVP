using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyPVP.Logic.RiotLogic.Patcher
{
    public class News
    {
        public string title { get; set; }
        public string description { get; set; }
        public string imageUrl { get; set; }
        public string thumbUrl { get; set; }
        public string linkUrl { get; set; }
        public string created { get; set; }
    }

    public class Promo
    {
        public string title { get; set; }
        public string promoText { get; set; }
        public string imageUrl { get; set; }
        public string thumbUrl { get; set; }
        public string linkUrl { get; set; }
    }

    public class Item2
    {
        public string id { get; set; }
        public string inventory_type { get; set; }
        public string item_id { get; set; }
        public string icon_url { get; set; }
        public string quantity { get; set; }
        public string max_quantity { get; set; }
        public object ip_cost { get; set; }
        public string rp_cost { get; set; }
        public string created { get; set; }
        public string release_date { get; set; }
        public object inactive_date { get; set; }
        public string active { get; set; }
        public string name_id { get; set; }
        public object description_id { get; set; }
        public List<string> tags { get; set; }
        public string product_id { get; set; }
        public string metadata { get; set; }
        public bool is_purchasable { get; set; }
        public bool is_rentable { get; set; }
        public List<string> db_tags { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public object end_date { get; set; }
        public object winCountRemaining { get; set; }
        public object sort_order { get; set; }
        public bool is_sale { get; set; }
        public bool is_featured { get; set; }
        public bool is_new { get; set; }
        public bool is_hot { get; set; }
        public string original_rp_cost { get; set; }
        public object original_ip_cost { get; set; }
        public string new_index { get; set; }
        public string icon_absolute_url { get; set; }
        public string buy_url { get; set; }
        public string info_url { get; set; }
        public string feature_index { get; set; }
    }

    public class ItemFeaturedSchedule
    {
        public string id { get; set; }
        public string item_id { get; set; }
        public object created { get; set; }
        public object start_date { get; set; }
        public object end_date { get; set; }
        public string active { get; set; }
        public string rank { get; set; }
        public string featured_type { get; set; }
    }

    public class Item
    {
        public Item2 Item { get; set; }
        public List<object> ItemPricingSchedule { get; set; }
        public List<ItemFeaturedSchedule> ItemFeaturedSchedule { get; set; }
        public List<object> BundleItems { get; set; }
    }

    public class Videos
    {
        public string id { get; set; }
        public string created { get; set; }
        public string title { get; set; }
        public string url { get; set; }
        public string start_date { get; set; }
        public string end_date { get; set; }
        public bool active { get; set; }
        public string info_url_override { get; set; }
        public string buy_url_override { get; set; }
        public string item_id { get; set; }
        public string sort { get; set; }
    }

    public class Spotlight
    {
        public Videos Videos { get; set; }
    }

    public class RootObject
    {
        public List<News> news { get; set; }
        public List<Promo> promos { get; set; }
        public List<object> takeoverItems { get; set; }
        public List<Item> items { get; set; }
        public List<object> banners { get; set; }
        public List<Spotlight> spotlight { get; set; }
    }
}
