package md5adf3ead4ef3ddc194fe7922d1a37a1c4;


public class FlashCardFragment
	extends android.support.v4.app.Fragment
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("project.FlashCardFragment, project", FlashCardFragment.class, __md_methods);
	}


	public FlashCardFragment ()
	{
		super ();
		if (getClass () == FlashCardFragment.class)
			mono.android.TypeManager.Activate ("project.FlashCardFragment, project", "", this, new java.lang.Object[] {  });
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
