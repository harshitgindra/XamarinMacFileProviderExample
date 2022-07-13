using AppKit;
using FileProvider;
using Foundation;

namespace XamarinMacFileProviderExample
{
	[Register ("AppDelegate")]
	public class AppDelegate : NSApplicationDelegate
	{
		private NSFileProviderDomain fileProviderDomain;
		private NSFileProviderManager fileProviderManager;

		public AppDelegate ()
		{
			this.fileProviderDomain = new NSFileProviderDomain(SharedIdentifiers.FileProviderDomains.primaryDomainIdentifier, SharedIdentifiers.FileProviderDomains.primaryDomainDisplayName);
		}

		public override void DidFinishLaunching (NSNotification notification)
		{
			Mount();
		}

		public override void WillTerminate (NSNotification notification)
		{
			// Insert code here to tear down your application
		}

		public void Mount()
		{
			NSFileProviderManager.GetDomains((domains, error) =>
			{
				if (error != null)
				{
					RegisterDomain();
					return;
				}

				bool foundDomain = false;

				foreach (NSFileProviderDomain domain in domains)
				{
					if (domain.Identifier.Equals(fileProviderDomain.Identifier) && domain.DisplayName.Equals(fileProviderDomain.DisplayName))
					{
						foundDomain = true;
					}
					else
					{
					}
				}

				if (foundDomain)
				{
					// TODO: follow-up CR brings this: ReEnumerateWorkingSet();
					return;
				}
				else
				{
					RegisterDomain();
				}
			});
		}

		private void RegisterDomain()
		{
			NSFileProviderManager.AddDomain(fileProviderDomain, (NSError error) =>
			{
				if (error != null)
				{
					System.nint code = error.Code;
					return;

					/*
                    enum NSFileProviderError : long
		            NotAuthenticated = -1000,
		            FilenameCollision = -1001,
		            SyncAnchorExpired = -1002,
		            PageExpired = SyncAnchorExpired,
		            InsufficientQuota = -1003,
		            ServerUnreachable = -1004,
		            NoSuchItem = -1005,
		            VersionOutOfDate = -1006,
		            DirectoryNotEmpty = -1007,
		            ProviderNotFound = -2001,
		            ProviderTranslocated = -2002,
		            OlderExtensionVersionRunning = -2003,
		            NewerExtensionVersionFound = -2004,
		            CannotSynchronize = -2005,
		            NonEvictableChildren = -2006,
		            UnsyncedEdits = -2007,
		            NonEvictable = -2008,
		            VersionNoLongerAvailable = -2009,
                    */
				}
			});
		}
	}

	static public class SharedIdentifiers
	{
		static public class FileProviderDomains
		{
			static public string primaryDomainIdentifier = "com.hgindra.xamarinmacfileproviderexample";
			static public string primaryDomainDisplayName = "Documents";
		}
	}
}

