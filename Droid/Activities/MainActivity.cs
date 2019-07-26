using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using Android.Support.V4.App;
using Android.Support.V4.View;
using Android.Widget;
using System.Collections.Generic;
using Android.Graphics;

namespace HeaderLineTime.Droid
{
    [Activity(Label = "@string/app_name", Icon = "@mipmap/icon",
        LaunchMode = LaunchMode.SingleInstance,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
        ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : BaseActivity
    {
        protected override int LayoutResource => Resource.Layout.activity_main;

        ViewPager pager;
        List<Button> stages = new List<Button>();
        //public TabsAdapter adapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            pager = FindViewById<ViewPager>(Resource.Id.viewpager);
            adapter = new TabsAdapter(this, SupportFragmentManager, pager);
            //var tabs = FindViewById<TabLayout>(Resource.Id.tabs);
            pager.Adapter = adapter;
            //tabs.SetupWithViewPager(pager);
            pager.OffscreenPageLimit = 3;
            stages.Add(FindViewById<Button>(Resource.Id.stage1));
            stages.Add(FindViewById<Button>(Resource.Id.stage2));
            stages.Add(FindViewById<Button>(Resource.Id.stage3));
            GrayStages();
            stages[0].SetBackgroundColor(Color.Red);
            pager.PageSelected += (sender, args) =>
            {
                var fragment = adapter.InstantiateItem(pager, args.Position) as IFragmentVisible;

                fragment?.BecameVisible();
            };


        }

        void GrayStages()
        {

            foreach (Button stage in stages)
            {
                stage.SetBackgroundColor(Color.Gray);
            }
        }

        public void changeFragment(int position)
        {
            GrayStages();
            stages[position].SetBackgroundColor(Color.Red);
            pager.SetCurrentItem(position, false);
            //var fragment = adapter.InstantiateItem(pager, position) as IFragmentVisible;

            //fragment?.BecameVisible();
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.top_menus, menu);
            return base.OnCreateOptionsMenu(menu);
        }
    }

    public class TabsAdapter : FragmentStatePagerAdapter
    {
        string[] titles;
        public BaseActivity Activity;
        private ViewPager pager;

        public override int Count => titles.Length;

        public TabsAdapter(Context context, Android.Support.V4.App.FragmentManager fm, ViewPager pager) : base(fm)
        {
            titles = context.Resources.GetTextArray(Resource.Array.sections);
            this.pager = pager;
        }

        public override Java.Lang.ICharSequence GetPageTitleFormatted(int position) =>
                            new Java.Lang.String(titles[position]);

        public override Android.Support.V4.App.Fragment GetItem(int position)
        {
            switch (position)
            {
                case 0: return BrowseFragment.NewInstance();
                case 1: return AboutFragment.NewInstance();
            }
            return null;
        }

        public override int GetItemPosition(Java.Lang.Object frag) => PositionNone;
    }
}
