package md5adf3ead4ef3ddc194fe7922d1a37a1c4;


public class HomeActivity
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("project.HomeActivity, project", HomeActivity.class, __md_methods);
	}


	public HomeActivity ()
	{
		super ();
		if (getClass () == HomeActivity.class)
			mono.android.TypeManager.Activate ("project.HomeActivity, project", "", this, new java.lang.Object[] {  });
	}

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
