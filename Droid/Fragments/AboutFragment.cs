using System;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace HeaderLineTime.Droid
{
    public class AboutFragment : Android.Support.V4.App.Fragment, IFragmentVisible
    {
        Button BackStep;

        public static AboutFragment NewInstance()
        {
            return new AboutFragment { Arguments = new Bundle() };
        }

        public AboutViewModel ViewModel { get; set; }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        Button learnMoreButton;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.fragment_about, container, false);
            ViewModel = new AboutViewModel();
            BackStep = view.FindViewById<Button>(Resource.Id.backStep);
            return view;
        }

        public override void OnStart()
        {
            base.OnStart();
            BackStep.Click += BackStepClick;
        }

        public override void OnStop()
        {
            base.OnStop();
            BackStep.Click -= BackStepClick;
        }

        public void BecameVisible()
        {

        }



        void BackStepClick(object sender, EventArgs e)
        {
            ((MainActivity)this.Activity).changeFragment(0);
            //var fragment = baseAdapter.InstantiateItem(pager, 1) as IFragmentVisible;
            //fragment?.BecameVisible();
        }
    }
}
