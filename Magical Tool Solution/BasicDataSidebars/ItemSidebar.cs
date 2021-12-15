using Magical_Tool_Solution.DataViews.Selectors;
using Magical_Tool_Solution.Interfaces;
using MTSLibrary;
using MTSLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Minimal_Tool_Stock_Calculator.BasicDataSidebars
{
    public partial class ItemSidebar : Form
    {
        private readonly ItemType _itemType;
        private readonly Form callingForm;
        private readonly ISelectClGr _selectClGr;
        private int pSuitability = 0;
        private int mSuitability = 0;
        private int kSuitability = 0;
        private int nSuitability = 0;
        private int sSuitability = 0;
        private int hSuitability = 0;
        public ItemSidebar(ItemType itemType, SuitabilityModel suitability, Form caller, ISelectClGr selectClGr)
        {
            _itemType = itemType;
            callingForm = caller;
            _selectClGr = selectClGr;
            InitializeComponent();
            AdjustUI();
            LoadSuitability(suitability);
            WireUpSuitability();
        }

        private void LoadSuitability(SuitabilityModel suitability)
        {
            if (suitability == null)
            {
                materialSuitabilityPanel.Visible = false;
            }
            else
            {
                pSuitability = suitability.PSuitability;
                mSuitability = suitability.MSuitability;
                kSuitability = suitability.KSuitability;
                nSuitability = suitability.NSuitability;
                sSuitability = suitability.SSuitability;
                hSuitability = suitability.HSuitability;
            }
        }

        private void AdjustUI()
        {
            if (_itemType == ItemType.comp)
            {
                basicDataLabel.Text = "Basic Component Data";
                modeSpecificLabel.Text = "Component Manufacturer:";
            }
            else if (_itemType == ItemType.tool)
            {
                basicDataLabel.Text = "Basic Tool Data";
                modeSpecificLabel.Text = "Machine interface:";
            }
        }

        public void WireUpSuitability()
        {
            if (pSuitability == 0)
            {
                pExLabel.BackColor = Color.White;
                pGoodLabel.BackColor = Color.White;
                pPoorLabel.BackColor = Color.White;
                pMaterialLabel.Tag = pSuitability;
            }
            else if (pSuitability == 1)
            {
                pExLabel.BackColor = Color.White;
                pGoodLabel.BackColor = Color.White;
                pPoorLabel.BackColor = Color.FromArgb(128, 128, 244);
                pMaterialLabel.Tag = pSuitability;
            }
            else if (pSuitability == 2)
            {
                pExLabel.BackColor = Color.White;
                pGoodLabel.BackColor = Color.FromArgb(128, 128, 244);
                pPoorLabel.BackColor = Color.FromArgb(128, 128, 244);
                pMaterialLabel.Tag = pSuitability;
            }
            else
            {
                pExLabel.BackColor = Color.FromArgb(128, 128, 244);
                pGoodLabel.BackColor = Color.FromArgb(128, 128, 244);
                pPoorLabel.BackColor = Color.FromArgb(128, 128, 244);
                pMaterialLabel.Tag = pSuitability;
            }
            if (mSuitability == 0)
            {
                mExLabel.BackColor = Color.White;
                mGoodLabel.BackColor = Color.White;
                mPoorLabel.BackColor = Color.White;
                mMaterialLabel.Tag = mSuitability;
            }
            else if (mSuitability == 1)
            {
                mExLabel.BackColor = Color.White;
                mGoodLabel.BackColor = Color.White;
                mPoorLabel.BackColor = Color.FromArgb(255, 255, 192);
                mMaterialLabel.Tag = mSuitability;
            }
            else if (mSuitability == 2)
            {
                mExLabel.BackColor = Color.White;
                mGoodLabel.BackColor = Color.FromArgb(255, 255, 192);
                mPoorLabel.BackColor = Color.FromArgb(255, 255, 192);
                mMaterialLabel.Tag = mSuitability;
            }
            else
            {
                mExLabel.BackColor = Color.FromArgb(255, 255, 192);
                mGoodLabel.BackColor = Color.FromArgb(255, 255, 192);
                mPoorLabel.BackColor = Color.FromArgb(255, 255, 192);
                mMaterialLabel.Tag = mSuitability;
            }
            if (kSuitability == 0)
            {
                kExLabel.BackColor = Color.White;
                kGoodLabel.BackColor = Color.White;
                kPoorLabel.BackColor = Color.White;
                kMaterialLabel.Tag = kSuitability;
            }
            else if (kSuitability == 1)
            {
                kExLabel.BackColor = Color.White;
                kGoodLabel.BackColor = Color.White;
                kPoorLabel.BackColor = Color.FromArgb(255, 128, 128);
                kMaterialLabel.Tag = kSuitability;
            }
            else if (kSuitability == 2)
            {
                kExLabel.BackColor = Color.White;
                kGoodLabel.BackColor = Color.FromArgb(255, 128, 128);
                kPoorLabel.BackColor = Color.FromArgb(255, 128, 128);
                kMaterialLabel.Tag = kSuitability;
            }
            else
            {
                kExLabel.BackColor = Color.FromArgb(255, 128, 128);
                kGoodLabel.BackColor = Color.FromArgb(255, 128, 128);
                kPoorLabel.BackColor = Color.FromArgb(255, 128, 128);
                kMaterialLabel.Tag = kSuitability;
            }
            if (nSuitability == 0)
            {
                nExLabel.BackColor = Color.White;
                nGoodLabel.BackColor = Color.White;
                nPoorLabel.BackColor = Color.White;
                nMaterialLabel.Tag = nSuitability;
            }
            else if (nSuitability == 1)
            {
                nExLabel.BackColor = Color.White;
                nGoodLabel.BackColor = Color.White;
                nPoorLabel.BackColor = Color.FromArgb(128, 255, 128);
                nMaterialLabel.Tag = nSuitability;
            }
            else if (nSuitability == 2)
            {
                nExLabel.BackColor = Color.White;
                nGoodLabel.BackColor = Color.FromArgb(128, 255, 128);
                nPoorLabel.BackColor = Color.FromArgb(128, 255, 128);
                nMaterialLabel.Tag = nSuitability;
            }
            else
            {
                nExLabel.BackColor = Color.FromArgb(128, 255, 128);
                nGoodLabel.BackColor = Color.FromArgb(128, 255, 128);
                nPoorLabel.BackColor = Color.FromArgb(128, 255, 128);
                nMaterialLabel.Tag = nSuitability;
            }
            if (sSuitability == 0)
            {
                sExLabel.BackColor = Color.White;
                sGoodLabel.BackColor = Color.White;
                sPoorLabel.BackColor = Color.White;
                sMaterialLabel.Tag = sSuitability;
            }
            else if (sSuitability == 1)
            {
                sExLabel.BackColor = Color.White;
                sGoodLabel.BackColor = Color.White;
                sPoorLabel.BackColor = Color.FromArgb(255, 192, 128);
                sMaterialLabel.Tag = sSuitability;
            }
            else if (sSuitability == 2)
            {
                sExLabel.BackColor = Color.White;
                sGoodLabel.BackColor = Color.FromArgb(255, 192, 128);
                sPoorLabel.BackColor = Color.FromArgb(255, 192, 128);
                sMaterialLabel.Tag = sSuitability;
            }
            else
            {
                sExLabel.BackColor = Color.FromArgb(255, 192, 128);
                sGoodLabel.BackColor = Color.FromArgb(255, 192, 128);
                sPoorLabel.BackColor = Color.FromArgb(255, 192, 128);
                sMaterialLabel.Tag = sSuitability;
            }
            if (hSuitability == 0)
            {
                hExLabel.BackColor = Color.White;
                hGoodLabel.BackColor = Color.White;
                hPoorLabel.BackColor = Color.White;
                hMaterialLabel.Tag = hSuitability;
            }
            else if (hSuitability == 1)
            {
                hExLabel.BackColor = Color.White;
                hGoodLabel.BackColor = Color.White;
                hPoorLabel.BackColor = Color.Silver;
                hMaterialLabel.Tag = hSuitability;
            }
            else if (hSuitability == 2)
            {
                hExLabel.BackColor = Color.White;
                hGoodLabel.BackColor = Color.Silver;
                hPoorLabel.BackColor = Color.Silver;
                hMaterialLabel.Tag = hSuitability;
            }
            else
            {
                hExLabel.BackColor = Color.Silver;
                hGoodLabel.BackColor = Color.Silver;
                hPoorLabel.BackColor = Color.Silver;
                hMaterialLabel.Tag = hSuitability;
            }
        }

        #region Suitability Click Handling
        private void PExLabel_Click(object sender, EventArgs e)
        {
            pSuitability = 3;
            WireUpSuitability();
        }

        private void PGoodLabel_Click(object sender, EventArgs e)
        {
            pSuitability = 2;
            WireUpSuitability();
        }

        private void PPoorLabel_Click(object sender, EventArgs e)
        {
            if (pSuitability != 1)
            {
                pSuitability = 1;
            }
            else
            {
                pSuitability = 0;
            }
            WireUpSuitability();
        }

        private void MExLabel_Click(object sender, EventArgs e)
        {
            mSuitability = 3;
            WireUpSuitability();
        }

        private void MGoodLabel_Click(object sender, EventArgs e)
        {
            mSuitability = 2;
            WireUpSuitability();
        }

        private void MPoorLabel_Click(object sender, EventArgs e)
        {
            if (mSuitability != 1)
            {
                mSuitability = 1;
            }
            else
            {
                mSuitability = 0;
            }
            WireUpSuitability();
        }

        private void KExLabel_Click(object sender, EventArgs e)
        {
            kSuitability = 3;
            WireUpSuitability();
        }

        private void KGoodLabel_Click(object sender, EventArgs e)
        {
            kSuitability = 2;
            WireUpSuitability();
        }

        private void KPoorLabel_Click(object sender, EventArgs e)
        {
            if (kSuitability != 1)
            {
                kSuitability = 1;
            }
            else
            {
                kSuitability = 0;
            }
            WireUpSuitability();
        }

        private void NExLabel_Click(object sender, EventArgs e)
        {
            nSuitability = 3;
            WireUpSuitability();
        }

        private void NGoodLabel_Click(object sender, EventArgs e)
        {
            nSuitability = 2;
            WireUpSuitability();
        }

        private void NPoorLabel_Click(object sender, EventArgs e)
        {
            if (nSuitability != 1)
            {
                nSuitability = 1;
            }
            else
            {
                nSuitability = 0;
            }
            WireUpSuitability();
        }

        private void SExLabel_Click(object sender, EventArgs e)
        {
            sSuitability = 3;
            WireUpSuitability();
        }

        private void SGoodLabel_Click(object sender, EventArgs e)
        {
            sSuitability = 2;
            WireUpSuitability();
        }

        private void SPoorLabel_Click(object sender, EventArgs e)
        {
            if (sSuitability != 1)
            {
                sSuitability = 1;
            }
            else
            {
                sSuitability = 0;
            }
            WireUpSuitability();
        }

        private void HExLabel_Click(object sender, EventArgs e)
        {
            hSuitability = 3;
            WireUpSuitability();
        }

        private void HGoodLabel_Click(object sender, EventArgs e)
        {
            hSuitability = 2;
            WireUpSuitability();
        }

        private void HPoorLabel_Click(object sender, EventArgs e)
        {
            if (hSuitability != 1)
            {
                hSuitability = 1;
            }
            else
            {
                hSuitability = 0;
            }
            WireUpSuitability();
        }
        #endregion

        private void ClgrSelectorButton_Click(object sender, EventArgs e)
        {
            Form form = new ClgrSelector(callingForm, _selectClGr);
            form.Visible = true;
            callingForm.Enabled = false;
        }
    }
}
