// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

// Warning: This code was generated by a tool.
// 
// Changes to this file may cause incorrect behavior and will be lost if the
// code is regenerated.

using Microsoft.Azure.Management.Compute.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Compute.Automation
{
    [Cmdlet("Add", "AzureRmVmssSecret")]
    [OutputType(typeof(VirtualMachineScaleSet))]
    public class AddAzureRmVmssSecretCommand : Microsoft.Azure.Commands.ResourceManager.Common.AzureRMCmdlet
    {
        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public VirtualMachineScaleSet VirtualMachineScaleSet { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 1,
            ValueFromPipelineByPropertyName = true)]
        public string SourceVaultId { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 2,
            ValueFromPipelineByPropertyName = true)]
        public VaultCertificate[] VaultCertificate { get; set; }

        protected override void ProcessRecord()
        {
            // VirtualMachineProfile
            if (this.VirtualMachineScaleSet.VirtualMachineProfile == null)
            {
                this.VirtualMachineScaleSet.VirtualMachineProfile = new Microsoft.Azure.Management.Compute.Models.VirtualMachineScaleSetVMProfile();
            }

            // OsProfile
            if (this.VirtualMachineScaleSet.VirtualMachineProfile.OsProfile == null)
            {
                this.VirtualMachineScaleSet.VirtualMachineProfile.OsProfile = new Microsoft.Azure.Management.Compute.Models.VirtualMachineScaleSetOSProfile();
            }

            // Secrets
            if (this.VirtualMachineScaleSet.VirtualMachineProfile.OsProfile.Secrets == null)
            {
                this.VirtualMachineScaleSet.VirtualMachineProfile.OsProfile.Secrets = new List<Microsoft.Azure.Management.Compute.Models.VaultSecretGroup>();
            }

            var vSecrets = new Microsoft.Azure.Management.Compute.Models.VaultSecretGroup();

            if (this.SourceVaultId != null)
            {
                // SourceVault
                vSecrets.SourceVault = new Microsoft.Azure.Management.Compute.Models.SubResource();
                vSecrets.SourceVault.Id = this.SourceVaultId;
            }
            vSecrets.VaultCertificates = this.VaultCertificate;
            this.VirtualMachineScaleSet.VirtualMachineProfile.OsProfile.Secrets.Add(vSecrets);
            WriteObject(this.VirtualMachineScaleSet);
        }
    }
}

