framework:
	cd framework-exporter && $(MAKE) framework EXPORT_DIRECTORY=$(abspath Build/framework)

package:
	cd unitypackage-exporter && $(MAKE) package EXPORT_DIRECTORY=$(abspath Build/package)
