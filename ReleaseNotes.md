# New in 15.2.0
* Support for GroupShare 2020 SR2
* Added support for ActivityV2 endpoints
* Added support for ExportActivityV2 endpoints
* Added support for TwoFactorAuthenticationSettings endpoints
* Added support for User2FAEnforcementStatusV2 endpoints

# New in 15.1.13
* Support for GroupShare 2020 SR1 CU13
* Added EnableSdlXliffAnalysisReport property to the ProjectTemplateSettingsV4 model

# New in 15.1.12
* Support for GroupShare 2020 SR1 CU12
* Added support for MTQEAnalysisReportsV3 endpoints
* Removed redundant, not working GetAnalysisReportsV3AsJson method (the default GetAnalysisReportsV3 method can be used instead)

# New in 15.1.11
* Support for GroupShare 2020 SR1 CU11
* Added support for ProjectTemplatesV3 endpoints
* Added support for ProjectTemplatesV4 endpoints
* Added support for ProjectSettings endpoints
* Added support for ProjectSettingsV4 endpoints
* Added support for SegmentLockingConfig endpoint
* Moved Dashboard endpoints from ProjectClient to ReportingClient

# New in 15.1.10
* Support for GroupShare 2020 SR1 CU10

# New in 15.1.9
* Support for GroupShare 2020 SR1 CU09

# New in 15.1.8
* Support for GroupShare 2020 SR1 CU08

# New in 15.1.7
* Support for GroupShare 2020 SR1 CU07

# New in 15.1.6
* Support for GroupShare 2020 SR1 CU06

# New in 1.3.6
* [#20](https://github.com/sdl/groupsharekit.net/pull/20)Added configurable TwelveHourDateTimeConverter
* [#22](https://github.com/sdl/groupsharekit.net/pull/22)Move service clients up to the interface and allow getting user environment variable
*

# New in 1.2.2
* custom DateTime converter which uses a default format string, though this can be overridden with an environment variable

# New in 1.2.0

* Added support obtaining project analysis statistics
* Added support obtaining project file analysis statistics
* Added support obtaining project language analysis statistics
* Added support organization filtering based on the tag

# New in 1.1.5
* Added System.Net.Http latest version

# New in 1.1.4
* Added System.Net.Http latest version

# New in 1.1.3
* Updated Nuget dependencies

# New in 1.1.2
* Removed language code required validation for Analyse project

# New in 1.1.1
* Removed language code required validation for Analyse project as html

# New in 1.1
* Fixed Export Translation memory method. Translation memory is returned as byte[]
* Support for concordance search as plain text
* Support for text seach as plain text
* Support for  project analyse report

# New in 1.0.1

* Change Terminology Client naming
* Update Project Client to include project template and file actions

# New in 1.0

* Added support for GroupShare 2017 Rest API
* Update to .NET Standard library 1.3
* Support for creating and publishing a project
* Support for users, membership, organization and organization resources management
* Support for termbase : get termbase, search term in a specific termbase
* Support for add, update and delete term from a specific termbase
* Support for project templates
* Support for file download
* Support for license informations

* Added Support for Translation Memory Service
* Support for translation memory management
* Support for adding translation units, search translation units as plain text
* Support for importing and exporting translation units into a translation memory
* Support for database server, and containers management
* Support for fuzzy index
* Support for field and field template management

# New in 0.6.0

* Update to .Net Standard library 1.1
* Added ProjectPhaseId on the LanguageFiles model


# New in 0.5.0

* Support for defining role when creating user

# New in 0.4.0

* Full support for GroupShare Rest API

# New in 0.2.0

* First release with partial support for GroupShare API