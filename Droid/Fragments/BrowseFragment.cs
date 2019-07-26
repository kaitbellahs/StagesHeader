using System;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace HeaderLineTime.Droid
{
    public class BrowseFragment : Android.Support.V4.App.Fragment, IFragmentVisible
    {
        Button nextStep;

        public static BrowseFragment NewInstance()
        {
            return new BrowseFragment { Arguments = new Bundle() };
        }


        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {

            View view = inflater.Inflate(Resource.Layout.fragment_browse, container, false);

            nextStep = view.FindViewById<Button>(Resource.Id.nextStep);

            return view;
        }

        public override void OnStart()
        {
            base.OnStart();
            nextStep.Click += NextStepClick;

        }

        public override void OnStop()
        {
            base.OnStop();
            nextStep.Click -= NextStepClick;
        }

        void NextStepClick(object sender, EventArgs e)
        {
            ((MainActivity)this.Activity).changeFragment(1);
            //var fragment = baseAdapter.InstantiateItem(pager, 1) as IFragmentVisible;
            //fragment?.BecameVisible();
        }


        public void BecameVisible()
        {

        }
    }
}
