package md5adf3ead4ef3ddc194fe7922d1a37a1c4;


public class FetchAddressIntentService
	extends mono.android.app.IntentService
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onHandleIntent:(Landroid/content/Intent;)V:GetOnHandleIntent_Landroid_content_Intent_Handler\n" +
			"";
		mono.android.Runtime.register ("project.FetchAddressIntentService, project", FetchAddressIntentService.class, __md_methods);
	}


	public FetchAddressIntentService (java.lang.String p0)
	{
		super (p0);
		if (getClass () == FetchAddressIntentService.class)
			mono.android.TypeManager.Activate ("project.FetchAddressIntentService, project", "System.String, mscorlib", this, new java.lang.Object[] { p0 });
	}


	public FetchAddressIntentService ()
	{
		super ();
		if (getClass () == FetchAddressIntentService.class)
			mono.android.TypeManager.Activate ("project.FetchAddressIntentService, project", "", this, new java.lang.Object[] {  });
	}


	public void onHandleIntent (android.content.Intent p0)
	{
		n_onHandleIntent (p0);
	}

	private native void n_onHandleIntent (android.content.Intent p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
