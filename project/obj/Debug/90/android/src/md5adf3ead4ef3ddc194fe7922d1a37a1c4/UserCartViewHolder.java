package md5adf3ead4ef3ddc194fe7922d1a37a1c4;


public class UserCartViewHolder
	extends android.support.v7.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("project.UserCartViewHolder, project", UserCartViewHolder.class, __md_methods);
	}


	public UserCartViewHolder (android.view.View p0)
	{
		super (p0);
		if (getClass () == UserCartViewHolder.class)
			mono.android.TypeManager.Activate ("project.UserCartViewHolder, project", "Android.Views.View, Mono.Android", this, new java.lang.Object[] { p0 });
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
