/* 
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/. 
 * 
 * Copyright (c) 2015, MPL Ali Taheri Moghaddar ali.taheri.m@gmail.com
 * 
 * I humbly ask you/your company not to change the following assembly information:
 * 1- Title
 * 2- Description
 * 3- Copyright
 * But do please provide assembly signing information required by your company.
 */

using System.Reflection;

// Information about this assembly is defined by the following attributes.
// Change them to the values specific to your project.
using System.Runtime.CompilerServices;

[assembly: AssemblyTitle("Pablo")]
[assembly: AssemblyDescription("The heart of Pablo Engine.")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("Pablo Engine")]
[assembly: AssemblyCopyright("Ali Taheri Moghaddar ali.taheri.m@gmail.com")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// The assembly version has the format "{Major}.{Minor}.{Build}.{Revision}".
// The form "{Major}.{Minor}.*" will automatically update the build and revision,
// and "{Major}.{Minor}.{Build}.*" will update just the revision.

[assembly: AssemblyVersion("0.0.*")]

// The following attributes are used to specify the signing key for the assembly,
// if desired. See the Mono documentation for more information about signing.

//[assembly: AssemblyDelaySign(false)]
//[assembly: AssemblyKeyFile("")]

#if DEBUG
// Allow the test assembly to access the internal members.
[assembly: InternalsVisibleTo("Pablo.Test")]
#endif
