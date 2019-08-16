using System;
using Android;
using Android.App;
using Android.Arch.Lifecycle;
using Android.Content;
using Android.Content.PM;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Android.Locations;
using Android.Gms.Location;
using Android.Gms.Tasks;
using Android.Provider;
using Android.Support.Design.Widget;
using Android.Support.V4.App;
using Android.Support.V4.Content;
using Android.Util;
using Exception = Java.Lang.Exception;
using Object = Java.Lang.Object;
using String = System.String;
using Uri = Android.Net.Uri;
using System.Linq;
using System.Text;
using Android.Support.V7.Widget;

using Java.Lang;

using TaskStackBuilder = Android.Support.V4.App.TaskStackBuilder;
using Android.Media;
using project.Database;
using project.Model;

namespace project
{
    [Activity(Label = "Cart")]
    public class Cart : AppCompatActivity  
    {  
        RecyclerView mRecycleView;
        RecyclerView.LayoutManager mLayoutManager;
        TextView tcost, crtAmt;
        UserCartObject mUserCartObject;
        UserCartObjectAdapter mAdapter;
        public readonly string TAG = typeof(Cart).Name;
        public readonly int RequestPermissionsRequestCode = 34;
        public const string AddressRequestedKey = "address-request-pending";
        public const string LocationAddressKey = "location-address";
        public FusedLocationProviderClient mFusedLocationClient;
        public Location mLastLocation;
        public bool mAddressRequested;
        public string mAddressOutput;
        public AddressResultReceiver mResultReceiver;
        public EditText mLocationAddressTextView;
        public ProgressBar mProgressBar;
        public Button odrBtn;
        public ImageButton mFetchAddressButton;
        public int uid;
        public float totAmt;
        DatabaseL db = new DatabaseL();

        // Unique ID for our notification: 
        public static readonly int NOTIFICATION_ID = 1000;
        public static readonly string CHANNEL_ID = "location_notification";
        public static readonly string COUNT_KEY = "count";

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            ISharedPreferences pref = Application.Context.GetSharedPreferences("UserInfo", FileCreationMode.Private);
            string userName = pref.GetString("Usermail", String.Empty);
            try
            {
                //string user = Intent.GetStringExtra("usrID").Trim();

                //bool res = int.TryParse(user, out uid);

                //if (string.IsNullOrEmpty(user))
                //{
                    var query = db.selectallUser();
                    var query1 = query.Where(x => x.Email == userName).FirstOrDefault();

                    uid = query1.Uid;

                //}
                
            }

            catch (Exception ex)
            {
                Toast.MakeText(Application.Context, ex.ToString(), ToastLength.Short).Show();
            }
            


            mUserCartObject = new UserCartObject(uid);
            // Set our view from the "main" layout resource  
            SetContentView(Resource.Layout.activity_cart);

            mResultReceiver = new AddressResultReceiver(new Handler()) { Activity = this };

            mLocationAddressTextView = FindViewById<EditText>(Resource.Id.mLocationAddressTextView);
            mProgressBar = FindViewById<ProgressBar>(Resource.Id.mProgressBar);
            crtAmt = FindViewById<TextView>(Resource.Id.cAmount);
            odrBtn = FindViewById<Button>(Resource.Id.btnPlaceOrder);
            mFetchAddressButton = FindViewById<ImageButton>(Resource.Id.mFetchAddressButton);
            mFetchAddressButton.Click += FetchAddressButtonHandler;

            mAddressRequested = false;
            mAddressOutput = string.Empty;
            UpdateValuesFromBundle(savedInstanceState);

            mFusedLocationClient = LocationServices.GetFusedLocationProviderClient(this);

            UpdateUiWidgets();

            tcost = FindViewById<TextView>(Resource.Id.total);
            mRecycleView = FindViewById<RecyclerView>(Resource.Id.listCart);
            mLayoutManager = new LinearLayoutManager(this);
            mRecycleView.SetLayoutManager(mLayoutManager);
            mAdapter = new UserCartObjectAdapter(mUserCartObject);

            int tot = 0;
            for (int i = 0; i < mUserCartObject.numPhoto; i++)
            {
                tot += mUserCartObject[i].mPrice;
            }
            crtAmt.Text = tot.ToString();
            totAmt = (tot * 113 / 100);
            tcost.Text = totAmt.ToString();
            totAmt = (float)(System.Math.Truncate((double)totAmt * 100.0) / 100.0);
            mAdapter.ItemClick += MAdapter_ItemClick;
            mRecycleView.SetAdapter(mAdapter);

            odrBtn.Click += PlaceOrder_Click;

            CreateNotificationChannel();
        }

        void CreateNotificationChannel()
        {
            if (Build.VERSION.SdkInt < BuildVersionCodes.O)
            {
                // Notification channels are new in API 26 (and not a part of the
                // support library). There is no need to create a notification 
                // channel on older versions of Android.
                return;
            }

            var name = Resources.GetString(Resource.String.channel_name);
            var description = GetString(Resource.String.channel_description);
            var channel = new NotificationChannel(Cart.CHANNEL_ID, name, NotificationImportance.Default)
            {
                Description = description
            };

            var notificationManager = (NotificationManager)GetSystemService(NotificationService);
            notificationManager.CreateNotificationChannel(channel);
        }

        private void PlaceOrder_Click(object sender, System.EventArgs e)
        {
            mProgressBar.Visibility = ViewStates.Visible;
            if (string.IsNullOrEmpty(mLocationAddressTextView.Text)) 
            {
                Android.Support.V7.App.AlertDialog.Builder dialog = new Android.Support.V7.App.AlertDialog.Builder(this);
                Android.Support.V7.App.AlertDialog alert = dialog.Create();
                alert.SetTitle("No Address");
                alert.SetMessage("Address Not Entered");
                alert.SetButton(1,"OK", (c, ev) =>
                {
                    // Ok button click task  
                });
            }
            else
            {
                try
                {
                    Order odr = new Order()
                    {
                        Amount = totAmt,
                        Address = mLocationAddressTextView.Text,
                        Status = "Confirmed",
                        Uid = uid
                    };
                    Order ordr = odr;
                    var query = db.insertOrder(odr);

                }

                catch (Exception ex)
                {
                    Toast.MakeText(Application.Context, ex.ToString(), ToastLength.Short).Show();
                }
                mProgressBar.Visibility = ViewStates.Invisible;
            }
            
            Snackbar snackBar = Snackbar.Make(odrBtn, "Your Order is Placed !", Snackbar.LengthIndefinite).SetAction("Ok", (v) =>
            {
                NotifyNotification();
                
            });
            snackBar.Show();
        }

        private void NotifyNotification()
        {
            // Pass the current button press count value to the next activity:
            var valuesForActivity = new Bundle();
            valuesForActivity.PutInt(COUNT_KEY, 1);

            // When the user clicks the notification, SecondActivity will start up.
            var resultIntent = new Intent(this, typeof(Home));

            // Pass some values to SecondActivity:
            resultIntent.PutExtras(valuesForActivity);

            // Construct a back stack for cross-task navigation:
            var stackBuilder = TaskStackBuilder.Create(this);
            stackBuilder.AddParentStack(Class.FromType(typeof(Home)));
            stackBuilder.AddNextIntent(resultIntent);

            // Create the PendingIntent with the back stack:            
            var resultPendingIntent = stackBuilder.GetPendingIntent(0, (int)PendingIntentFlags.UpdateCurrent);

            // Build the notification:
            var builder = new NotificationCompat.Builder(this, CHANNEL_ID)
                          .SetAutoCancel(true) // Dismiss the notification from the notification area when the user clicks on it
                          .SetContentIntent(resultPendingIntent) // Start up this activity when the user clicks the intent.
                          .SetContentTitle("Confirmed") // Set the title
                          .SetNumber(1) // Display the count in the Content Info
                          .SetSmallIcon(Resource.Drawable.logo) // This is the icon to display
                          .SetContentText("Your order is confirmed by EatIt.") // the message to display.
                          .SetSound(RingtoneManager.GetDefaultUri(RingtoneType.Ringtone));

            // Finally, publish the notification:
            var notificationManager = NotificationManagerCompat.From(this);
            notificationManager.Notify(NOTIFICATION_ID, builder.Build());
            Console.WriteLine("Done");


            try
            {
                //cooking time: 180 sec
                Thread.Sleep(10000);
            }
            catch (InterruptedException e)
            {
                e.PrintStackTrace();
            }


            resultPendingIntent = stackBuilder.GetPendingIntent(0, (int)PendingIntentFlags.UpdateCurrent);

            // Build the notification:
            builder = new NotificationCompat.Builder(this, CHANNEL_ID)
                          .SetAutoCancel(true) // Dismiss the notification from the notification area when the user clicks on it
                          .SetContentIntent(resultPendingIntent) // Start up this activity when the user clicks the intent.
                          .SetContentTitle("Order Prepared!") // Set the title
                          .SetNumber(1) // Display the count in the Content Info
                          .SetSmallIcon(Resource.Drawable.logo) // This is the icon to display
                          .SetContentText("Your order is Prepared by EatIt.") // the message to display.
                          .SetSound(RingtoneManager.GetDefaultUri(RingtoneType.Ringtone));

            // Finally, publish the notification:
            notificationManager = NotificationManagerCompat.From(this);
            notificationManager.Notify(NOTIFICATION_ID, builder.Build());


            try
            {
                //cooking time: 180 sec
                Thread.Sleep(10000);
            }
            catch (InterruptedException e)
            {
                e.PrintStackTrace();
            }

            //Order Packaged
            resultPendingIntent = stackBuilder.GetPendingIntent(0, (int)PendingIntentFlags.UpdateCurrent);

            // Build the notification:
            builder = new NotificationCompat.Builder(this, CHANNEL_ID)
                          .SetAutoCancel(true) // Dismiss the notification from the notification area when the user clicks on it
                          .SetContentIntent(resultPendingIntent) // Start up this activity when the user clicks the intent.
                          .SetContentTitle("Order Packed!") // Set the title
                          .SetNumber(1) // Display the count in the Content Info
                          .SetSmallIcon(Resource.Drawable.logo) // This is the icon to display
                          .SetContentText("Your order is Packed by EatIt.") // the message to display.
                          .SetSound(RingtoneManager.GetDefaultUri(RingtoneType.Ringtone));

            // Finally, publish the notification:
            notificationManager = NotificationManagerCompat.From(this);
            notificationManager.Notify(NOTIFICATION_ID, builder.Build());
        }

        private void MAdapter_ItemClick(object sender, int e)
        {
        //int photoNum = e + 1;
        //Toast.MakeText(this, "This is photo number " + photoNum, ToastLength.Short).Show();
        }


        // LOcation

        protected override void OnStart()
        {
            base.OnStart();

            if (!CheckPermissions())
            {
                RequestPermissions();
            }
            else
            {
                GetAddress();
            }
        }

        private void UpdateValuesFromBundle(Bundle savedInstanceState)
        {
            if (savedInstanceState != null)
            {
                if (savedInstanceState.KeySet().Contains(AddressRequestedKey))
                {
                    mAddressRequested = savedInstanceState.GetBoolean(AddressRequestedKey);
                }
                if (savedInstanceState.KeySet().Contains(LocationAddressKey))
                {
                    mAddressOutput = savedInstanceState.GetString(LocationAddressKey);
                    DisplayAddressOutput();
                }
            }
        }

        public void FetchAddressButtonHandler(object sender, EventArgs eventArgs)
        {
            if (mLastLocation != null)
            {
                StartIntentService();
                return;
            }
            mAddressRequested = true;
            UpdateUiWidgets();
        }

        public void StartIntentService()
        {
            Intent intent = new Intent(this, typeof(FetchAddressIntentService));
            intent.PutExtra(Constants.Receiver, mResultReceiver);
            intent.PutExtra(Constants.LocationDataExtra, mLastLocation);
            StartService(intent);
        }

        public void GetAddress()
        {
            var lastLocation = mFusedLocationClient.LastLocation;
            lastLocation.AddOnSuccessListener(this, new GetAddressOnSuccessListener { Activity = this });
            lastLocation.AddOnFailureListener(this, new GetAddressOnFailureListener { Activity = this });
        }

        public void DisplayAddressOutput()
        {
            mLocationAddressTextView.Text = mAddressOutput;
        }

        public void UpdateUiWidgets()
        {
            if (mAddressRequested)
            {
                mProgressBar.Visibility = ViewStates.Visible;
                mFetchAddressButton.Enabled = false;
            }
            else
            {
                mProgressBar.Visibility = ViewStates.Gone;
                mFetchAddressButton.Enabled = true;
            }
        }

        public void ShowToast(String text)
        {
            Toast.MakeText(this, text, ToastLength.Short).Show();
        }

        protected override void OnSaveInstanceState(Bundle savedInstanceState)
        {
            savedInstanceState.PutBoolean(AddressRequestedKey, mAddressRequested);
            savedInstanceState.PutString(LocationAddressKey, mAddressOutput);
            base.OnSaveInstanceState(savedInstanceState);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            Log.Info(TAG, "onRequestPermissionResult");
            if (requestCode == RequestPermissionsRequestCode)
            {
                if (grantResults.Length <= 0)
                {
                    Log.Info(TAG, "User interaction was cancelled.");
                }
                else if (grantResults[0] == (int)Permission.Granted)
                {
                    GetAddress();
                }
                else
                {
                    ShowSnackbar(Resource.String.permission_denied_explanation, Resource.String.settings, new AddressResultReceiver.OnRequestPermissionsResultClickListener { Activity = this });
                }
            }
        }

        public void ShowSnackbar(string text)
        {
            View container = FindViewById(Android.Resource.Id.Content);
            if (container != null)
            {
                Snackbar.Make(container, text, Snackbar.LengthLong).Show();
            }
        }

        public void ShowSnackbar(int mainTextStringId, int actionStringId, View.IOnClickListener listener)
        {
            Snackbar.Make(FindViewById(Android.Resource.Id.Content), GetString(mainTextStringId), Snackbar.LengthIndefinite)
                .SetAction(GetString(actionStringId), listener).Show();
        }

        public bool CheckPermissions()
        {
            var permissionState = ContextCompat.CheckSelfPermission(this, Manifest.Permission.AccessFineLocation);
            return permissionState == (int)Permission.Granted;
        }

        public void RequestPermissions()
        {
            bool shouldProvideRationale = ActivityCompat.ShouldShowRequestPermissionRationale(this, Manifest.Permission.AccessFineLocation);

            if (shouldProvideRationale)
            {
                Log.Info(TAG, "Displaying permission rationale to provide additional context.");
                ShowSnackbar(Resource.String.permission_rationale, Android.Resource.String.Ok, new AddressResultReceiver.RequestPermissionsOnClickListener { Activity = this });
            }
            else
            {
                Log.Info(TAG, "Requesting permission");
                ActivityCompat.RequestPermissions(this, new[] { Manifest.Permission.AccessFineLocation }, RequestPermissionsRequestCode);
            }
        }
    }

    public class GetAddressOnSuccessListener : Object, IOnSuccessListener
    {

        public project.Cart Activity { get; set; }

        public void OnSuccess(Object location)
        {
            if (location == null)
            {
                Log.Warn(Activity.TAG, "onSuccess:null");
                return;
            }

            Activity.mLastLocation = (Location)location;

            if (!Geocoder.IsPresent)
            {
                Activity.ShowSnackbar(Activity.GetString(Resource.String.no_geocoder_available));
                return;
            }

            if (Activity.mAddressRequested)
            {
                Activity.StartIntentService();
            }
        }
    }

    public class GetAddressOnFailureListener : Java.Lang.Object, IOnFailureListener
    {

        public project.Cart Activity { get; set; }


        public void OnFailure(Exception e)
        {
            Log.Warn(Activity.TAG, "getLastLocation:onFailure", e);
        }
    }

    public class AddressResultReceiver : ResultReceiver
    {
        public Cart Activity { get; set; }
        public AddressResultReceiver(Handler handler) : base(handler) { }

        protected override void OnReceiveResult(int resultCode, Bundle resultData)
        {
            Activity.mAddressOutput = resultData.GetString(Constants.ResultDataKey);
            Activity.DisplayAddressOutput();

            if (resultCode == Constants.SuccessResult)
            {
                Activity.ShowToast(Activity.GetString(Resource.String.address_found));
            }

            Activity.mAddressRequested = false;
            Activity.UpdateUiWidgets();
        }

        public class RequestPermissionsOnClickListener : Object, View.IOnClickListener
        {
            public Cart Activity { get; set; }

            public void OnClick(View v)
            {
                ActivityCompat.RequestPermissions(Activity, new[] { Manifest.Permission.AccessFineLocation }, Activity.RequestPermissionsRequestCode);
            }
        }

        public class OnRequestPermissionsResultClickListener : Object, View.IOnClickListener
        {
            public Cart Activity { get; set; }
            public void OnClick(View v)
            {
                Intent intent = new Intent();
                intent.SetAction(Settings.ActionApplicationDetailsSettings);
                Uri uri = Uri.FromParts("package", Activity.PackageName, null);
                intent.SetData(uri);
                intent.SetFlags(ActivityFlags.NewTask);
                Activity.StartActivity(intent);
            }
        }


        

        //        RecyclerView recyclerView;
        //        RecyclerView.LayoutManager layoutManager;

        //        FirebaseDatabase database;
        //        DatabaseReference requests;

        //        TextView txtTotalPrice;
        //        Button btnPlace;
        //        float totalPrice;

        //        List<Order> cart = new ArrayList<>();
        //        CartAdapter adapter;

        //        //name the threads
        //        Thread inventorylistthread = new Thread(new IventoryListThread());
        //        Thread kitchenthread = new Thread(new KitchenThread());

        //        //name the variables in static, so they can be accessed and updated by the inventorylistthread
        //        static List<List<Order>> orderList = new ArrayList<>();
        //        static List<Food> inventoryList = new ArrayList<>();
        //        static Food inventory;
        //        static List<String> requestId = new ArrayList<>();
        //        //The orderList is for inventoryList, the requestList is for the KitchenThread
        //        static List<Request> requestList = new ArrayList<>();
        //        static float total;

        //        //partial request flag
        //        private boolean partial = false;

        //        //unavailable food information
        //        static String unavailablefoodnames = "";
        //        static float unavailablefoodprice = 0;

        //        //The executor can makes inventorylistthread running in interval, which is 1 hour
        //        ScheduledExecutorService executor = Executors.newSingleThreadScheduledExecutor();

        //        @Override
        //    protected void onCreate(Bundle savedInstanceState)
        //        {
        //            super.onCreate(savedInstanceState);
        //            setContentView(R.layout.activity_cart);

        //            //thread running in 1 hour interval
        //            executor.scheduleAtFixedRate(inventorylistthread, 0, 60, TimeUnit.MINUTES);

        //            //Firebase
        //            database = FirebaseDatabase.getInstance();
        //            requests = database.getReference("Requests");

        //            //Init
        //            recyclerView = findViewById(R.id.listCart);
        //            recyclerView.setHasFixedSize(true);
        //            layoutManager = new LinearLayoutManager(this);
        //            recyclerView.setLayoutManager(layoutManager);

        //            txtTotalPrice = findViewById(R.id.total);
        //            btnPlace = findViewById(R.id.btnPlaceOrder);

        //            //When the "Place Order" button clicked
        //            btnPlace.setOnClickListener(new View.OnClickListener() {
        //            @Override
        //            public void onClick(View v)
        //            {
        //                //update invetoryList immediately first
        //                executor.scheduleAtFixedRate(inventorylistthread, 0, 60, TimeUnit.MINUTES);
        //                if (!checkavailability(cart))
        //                {

        //                    //Create new Request
        //                    showAlertDialog();

        //                }
        //                else
        //                {

        //                    //Show user the "Partial order or cancel order options" dialog,
        //                    System.out.println("Food Unavailble");
        //                    AlertDialog.Builder alertPartialDialog = new AlertDialog.Builder(Cart.this);
        //                    alertPartialDialog.setTitle(unavailablefoodnames + " is unavailable");
        //                    unavailablefoodnames = "";
        //                    alertPartialDialog.setMessage("Do you accept partial order ?");

        //                    alertPartialDialog.setPositiveButton("YES", new DialogInterface.OnClickListener(){

        //                        @Override
        //                        public void onClick(DialogInterface dialog, int which)
        //                    {
        //                        partial = true;
        //                        showAlertDialog();
        //                    }
        //                });

        //            alertPartialDialog.show();

        //            //If user choose Partial order, then do showAlertDialog() again, and set the partial flag to true in order to set this request partially
        //            /*showAlertDialog();
        //            partial = true;*/

        //        }
        //    }
        //});

        //        loadListFood();

        //    }

        //    //Find out whether the foods in order contains unavailable food
        //    private boolean checkavailability(List<Order> cart)
        //{
        //    boolean partial = false;
        //    if (cart.size() == 0)
        //    {
        //        //Cart is empty, do nothing
        //        partial = true;
        //    }
        //    for (Order order : cart)
        //    {
        //        for (Food food: inventoryList)
        //        {
        //            /*System.out.println("SH-----------IT"+food.getFoodId());
        //            System.out.println("FU-----------CK"+order.getProductId());
        //            System.out.println("DA-----------MN"+food.getAvailabilityFlag());*/
        //            if (food.getFoodId().equals(order.getProductId()))
        //            {
        //                if (food.getAvailabilityFlag().equals("0"))
        //                {
        //                    //if the availabilityFlag of this food is "0"
        //                    partial = true;
        //                    unavailablefoodprice += Integer.parseInt(food.getPrice());
        //                    unavailablefoodprice = (float)(unavailablefoodprice * 1.36);
        //                    unavailablefoodnames += food.getName();
        //                }
        //            }
        //        }


        //    }
        //    return partial;
        //}

        //private void showAlertDialog()
        //{
        //    AlertDialog.Builder alertDialog = new AlertDialog.Builder(Cart.this);
        //    alertDialog.setTitle("One more step!");
        //    alertDialog.setMessage("Enter your address");
        //    System.out.println("email address ");
        //    final EditText edtAddress = new EditText(Cart.this);
        //    LinearLayout.LayoutParams lp = new LinearLayout.LayoutParams(
        //            LinearLayout.LayoutParams.MATCH_PARENT,
        //            LinearLayout.LayoutParams.MATCH_PARENT
        //    );

        //    edtAddress.setLayoutParams(lp);
        //    alertDialog.setView(edtAddress);
        //    alertDialog.setIcon(R.drawable.ic_shopping_cart_black_24dp);

        //    alertDialog.setPositiveButton("YES", new DialogInterface.OnClickListener() {
        //            @Override
        //            public void onClick(DialogInterface dialog, int which)
        //    {
        //        Request request = new Request(
        //                Common.currentUser.getPhone(),
        //                Common.currentUser.getName(),
        //                edtAddress.getText().toString(),
        //                txtTotalPrice.getText().toString(),
        //                cart
        //        );

        //        if (partial)
        //        {
        //            request.setPartial(true);
        //            //add the request to top of the requestList if it's partial request
        //            requestList.add(0, request);

        //            //default partial is false, set it back to false to check next request
        //            partial = false;

        //            //cut the price of unavailable food
        //            //keep track of totalprice using global variable
        //            //txtTotalPrice is in currency format unable to parse
        //            Locale locale = new Locale("en", "US");
        //            NumberFormat fmt = NumberFormat.getCurrencyInstance(locale);
        //            request.setTotal(fmt.format(totalPrice - unavailablefoodprice));
        //            unavailablefoodprice = 0;



        //        }
        //        else
        //        {
        //            requestList.add(request);
        //        }

        //        //Submit to Firebase
        //        //We will using System.Current
        //        requestId.add(String.valueOf(System.currentTimeMillis()));
        //        requests.child(requestId.get(requestId.size() - 1)).setValue(request);

        //        //run the kitchenthread
        //        kitchenthread.start();

        //        //Delete the cart
        //        new Database(getBaseContext()).cleanCart();

        //        Toast.makeText(Cart.this, "Thank you, Order placed", Toast.LENGTH_SHORT).show();
        //        finish();

        //        //                Code to show notification
        //        Intent intent = new Intent();
        //        PendingIntent pendingIntent = PendingIntent.getActivity(Cart.this, 0, intent, 0);
        //        Notification.Builder notificationBuilder = new Notification.Builder(Cart.this)
        //                .setTicker("Order Placed").setContentTitle("Order Placed")
        //                .setContentText("Your order is processing now").setSmallIcon(R.drawable.logo)
        //                .setContentIntent(pendingIntent);
        //        Notification notification = notificationBuilder.build();
        //        notification.flags = Notification.FLAG_AUTO_CANCEL;
        //        NotificationManager nm = (NotificationManager)getSystemService(NOTIFICATION_SERVICE);
        //        assert nm != null;
        //        nm.notify(0, notification);
        //    }
        //});


        //        /*alertDialog.setPositiveButton("NO", new DialogInterface.OnClickListener() {
        //            @Override
        //            public void onClick(DialogInterface dialog, int which) {
        //                dialog.dismiss();
        //            }
        //        });*/

        //        alertDialog.show();
        //        //                This code is to show notifications in android status bar when user places order
        //        // notification is selected



        //    }

        //    //this thread cooks requests
        //    class KitchenThread implements Runnable
        //{

        //    @Override
        //        public void run()
        //{
        //    while (true)
        //    {
        //        while (requestList.size() > 0)
        //        {
        //            DatabaseReference requests = FirebaseDatabase.getInstance().getReference("Requests");
        //            requests.child(requestId.get(0)).child("status").setValue("1");
        //            System.out.println("The chef is working on requests!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");

        //            Intent intent = new Intent();
        //            PendingIntent pendingIntent = PendingIntent.getActivity(Cart.this, 0, intent, 0);
        //            Notification.Builder notificationBuilder = new Notification.Builder(Cart.this)
        //                    .setTicker("Order Accepted").setContentTitle("Order Accepted")
        //                    .setContentText("The Chef is working on your order").setSmallIcon(R.drawable.logo)
        //                    .setContentIntent(pendingIntent);
        //            Notification notification = notificationBuilder.build();
        //            notification.flags = Notification.FLAG_AUTO_CANCEL;
        //            NotificationManager nm = (NotificationManager)getSystemService(NOTIFICATION_SERVICE);
        //            assert nm != null;
        //            nm.notify(0, notification);

        //            try
        //            {
        //                //cooking time: 180 sec
        //                Thread.sleep(10000);
        //            }
        //            catch (InterruptedException e)
        //            {
        //                e.printStackTrace();
        //            }

        //            System.out.println("Order Prepared!");

        //            Intent intent1 = new Intent();
        //            PendingIntent pendingIntent1 = PendingIntent.getActivity(Cart.this, 0, intent1, 0);
        //            Notification.Builder notificationBuilder1 = new Notification.Builder(Cart.this)
        //                    .setTicker("Order Prepared").setContentTitle("Order Prepared")
        //                    .setContentText("Your order is prepared").setSmallIcon(R.drawable.logo)
        //                    .setContentIntent(pendingIntent1);
        //            Notification notification1 = notificationBuilder1.build();
        //            notification1.flags = Notification.FLAG_AUTO_CANCEL;
        //            NotificationManager nm1 = (NotificationManager)getSystemService(NOTIFICATION_SERVICE);
        //            assert nm1 != null;
        //            nm1.notify(0, notification1);

        //            requests.child(requestId.get(0)).child("status").setValue("2");
        //            try
        //            {
        //                //packaging time: 180 sec
        //                Thread.sleep(10000);
        //            }
        //            catch (InterruptedException e)
        //            {
        //                e.printStackTrace();
        //            }
        //            System.out.println("Order Packaged!");

        //            Intent intent2 = new Intent();
        //            PendingIntent pendingIntent2 = PendingIntent.getActivity(Cart.this, 0, intent2, 0);
        //            Notification.Builder notificationBuilder2 = new Notification.Builder(Cart.this)
        //                    .setTicker("Order Packaged").setContentTitle("Order Packaged")
        //                    .setContentText("Your order is packaged and ready to pick up!").setSmallIcon(R.drawable.logo)
        //                    .setContentIntent(pendingIntent2);
        //            Notification notification2 = notificationBuilder2.build();
        //            notification2.flags = Notification.FLAG_AUTO_CANCEL;
        //            NotificationManager nm2 = (NotificationManager)getSystemService(NOTIFICATION_SERVICE);
        //            assert nm2 != null;
        //            nm2.notify(0, notification2);

        //            requests.child(requestId.get(0)).child("status").setValue("3");

        //            //The first request finished, generate receipt, then remove the finished request, working on next request in list
        //            Looper.prepare();
        //            Toast.makeText(Cart.this, GenerateReceipt(requestList.get(0)), Toast.LENGTH_SHORT).show();
        //            requestList.remove(0);
        //            requestId.remove(0);

        //            Looper.loop();

        //        }
        //        System.out.println("there are no requests yet, what a terrible day!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
        //    }
        //}

        //public String GenerateReceipt(Request request)
        //{
        //    Receipt receipt = new Receipt();
        //    receipt.items = request.getFoods();
        //    receipt.totalcost = request.getTotal();
        //    String message = "---------Food Ready! Thank you!---------\n";
        //    for (Order i:receipt.items)
        //    {
        //        message += i.getProductName() + " :" + i.getQuanlity() + "\n";
        //    }
        //    message += "Total: " + total;
        //    return message;


        //}
        //    }


        //    private void loadListFood()
        //{
        //    cart = new Database(this).getCarts();
        //    orderList.add(cart);
        //    adapter = new CartAdapter(cart, this);
        //    recyclerView.setAdapter(adapter);

        //    //Calculate total price
        //    total = 0;
        //    for (Order order:cart)
        //        total += (float)(Integer.parseInt(order.getPrice())) * (Integer.parseInt(order.getQuanlity()));
        //    Locale locale = new Locale("en", "US");
        //    NumberFormat fmt = NumberFormat.getCurrencyInstance(locale);


        //    // add tax, profit to total, do we need to show the tax and profit on the app??
        //    float tax = (float)(total * 0.06);
        //    float profit = (float)(total * 0.3);
        //    total += tax + profit;

        //    totalPrice = total;

        //    txtTotalPrice.setText(fmt.format(total));

        //}

        ////Delete item


        //@Override
        //    public boolean onContextItemSelected(MenuItem item)
        //{
        //    System.out.println("I CAME HERE?");
        //    System.out.println(item.getTitle());
        //    if (item.getTitle().equals(Common.DELETE))
        //    {
        //        System.out.println("I CAME HERE YAY");
        //        System.out.println(item.getItemId());
        //        System.err.println(item.getOrder());
        //        deleteFoodItem(item.getOrder());
        //    }
        //    return super.onContextItemSelected(item);
        //}

        //private void deleteFoodItem(int ord)
        //{
        //    cart = new Database(this).getCarts();
        //    String order1 = cart.get(ord).getProductId();
        //    System.out.println("The order is " + order1);
        //    for (Order order:cart)
        //    {
        //        System.err.println("The order id is " + order.getProductId());
        //        if (order.getProductId().equals(order1))
        //        {
        //            System.err.println(order.getProductName());
        //            System.err.println("I CAME HERE FUCK YEAAAAAHHHHHH");
        //            new Database(getBaseContext()).removeFromCart(order1);
        //        }
        //    }
        //    loadListFood();
        //}
    }
}