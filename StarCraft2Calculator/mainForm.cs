using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StarCraft2Calculator
{
    public partial class mainForm : Form
    {
        // Input Variables
        int[] hpInt = new int[2] { 0, 0 };
        int[] spInt = new int[2] { 0, 0 };
        int[] baseArmorInt = new int[2] { 0, 0 };
        int[] baseSpAmrInt = new int[2] { 0, 0 };
        int[] armorUpgradesInt = new int[2] { 0, 0 };
        int[] spUpgradesInt = new int[2] { 0, 0 };
        int[] baseDmgInt = new int[2] { 0, 0 };
        int[] spDmgInt = new int[2] { 0, 0 };
        int[] airDmgInt = new int[2] { 0, 0 };
        int[] airSpDmgInt = new int[2] { 0, 0 };
        int[] attDmg1Int = new int[2] { 0, 0 };
        int[] airAttDmg1Int = new int[2] { 0, 0 };
        int[] attDmg2Int = new int[2] { 0, 0 };
        int[] airAttDmg2Int = new int[2] { 0, 0 };
        int[] attDmg3Int = new int[2] { 0, 0 };
        int[] airAttDmg3Int = new int[2] { 0, 0 };
        int[] atkPerShotInt = new int[2] { 0, 0 };
        int[] airAtkPerShotInt = new int[2] { 0, 0 };
        int[] wpnUpgradesInt = new int[2] { 0, 0 };
        double[] wpnCooldownDbl = new double[2] { 0, 0 };
        double[] airWpnCooldownDbl = new double[2] { 0, 0 };

        string[] unitString = new string[2];
        string[] att1String = new string[2];
        string[] att2String = new string[2];
        string[] att3String = new string[2];
        string[] attDmg1String = new string[2];
        string[] attDmg2String = new string[2];
        string[] attDmg3String = new string[2];

    // Output Variables
        int[] armorInt = new int[2];
        int[] spAmrInt = new int[2];
        double[] dpShotDbl = new double[2];
        double[] airDpShotDbl = new double[2];
        double[] dpShotSpDbl = new double[2];
        double[] airDpShotSpDbl = new double[2];
        double[] dpSecondDbl = new double[2];
        double[] airDpSecondDbl = new double[2];
        double[] dpSecondSpDbl = new double[2];
        double[] airDpSecondSpDbl = new double[2];
        int[] shotsKillInt = new int[2];
        int[] airShotsKillInt = new int[2];
        double[] secKillDbl = new double[2];
        double[] airSecKillDbl = new double[2];
        double[] spOverkillDbl = new double[2];
        double[] overkillDbl = new double[2];
        double[] airOverkillDbl = new double[2];

        // Variables for calculations
        int[] shotCounterInt = new int[2] { 0, 0 };
        double[] spRemainingDbl = new double[2];
        double[] hpRemainingDbl = new double[2];
        double[] totalSpDmgDbl = new double[2];

        CheckBox[] groundBox = new CheckBox[2];
        CheckBox[] airBox = new CheckBox[2];
        CheckBox[] spellBox = new CheckBox[2];
        CheckBox[] airSpellBox = new CheckBox[2];

        int i;
        int a;

        public mainForm()
        { InitializeComponent(); }

        // Calculates as user types
        private void tb_TextChanged(object sender, EventArgs e)
        {
            // [0] = Left Side, [1] = Right Side

            // Insures inputs are valid and sets input variables before proceeding with calculations
            if (int.TryParse(lHpTextBox.Text, out hpInt[0]) &&
                int.TryParse(rHpTextBox.Text, out hpInt[1]) &&
                int.TryParse(lSpTextBox.Text, out spInt[0]) &&
                int.TryParse(rSpTextBox.Text, out spInt[1]) &&
                int.TryParse(lBseAmrTextBox.Text, out baseArmorInt[0]) &&
                int.TryParse(rBseAmrTextBox.Text, out baseArmorInt[1]) &&
                int.TryParse(lSpAmrTextBox.Text, out baseSpAmrInt[0]) &&
                int.TryParse(rSpAmrTextBox.Text, out baseSpAmrInt[1]) &&
                int.TryParse(lAmrUpgTextBox.Text, out armorUpgradesInt[0]) &&
                int.TryParse(rAmrUpgTextBox.Text, out armorUpgradesInt[1]) &&
                int.TryParse(lSpUpgTextBox.Text, out spUpgradesInt[0]) &&
                int.TryParse(rSpUpgTextBox.Text, out spUpgradesInt[1]) &&
                int.TryParse(lBseDmgTextBox.Text, out baseDmgInt[0]) &&
                int.TryParse(rBseDmgTextBox.Text, out baseDmgInt[1]) &&
                int.TryParse(lAirDmgTextBox.Text, out airDmgInt[0]) &&
                int.TryParse(rAirDmgTextBox.Text, out airDmgInt[1]) &&
                int.TryParse(lShieldDmgTextBox.Text, out spDmgInt[0]) &&
                int.TryParse(rShieldDmgTextBox.Text, out spDmgInt[1]) &&
                int.TryParse(lAirShieldDmgTextBox.Text, out airSpDmgInt[0]) &&
                int.TryParse(rAirShieldDmgTextBox.Text, out airSpDmgInt[1]) &&
                int.TryParse(lAttDmg1TextBox.Text, out attDmg1Int[0]) &&
                int.TryParse(rAttDmg1TextBox.Text, out attDmg1Int[1]) &&
                int.TryParse(lAirAttDmg1TextBox.Text, out airAttDmg1Int[0]) &&
                int.TryParse(rAirAttDmg1TextBox.Text, out airAttDmg1Int[1]) &&
                int.TryParse(lAttDmg2TextBox.Text, out attDmg2Int[0]) &&
                int.TryParse(rAttDmg2TextBox.Text, out attDmg2Int[1]) &&
                int.TryParse(lAirAttDmg2TextBox.Text, out airAttDmg2Int[0]) &&
                int.TryParse(rAirAttDmg2TextBox.Text, out airAttDmg2Int[1]) &&
                int.TryParse(lAttDmg3TextBox.Text, out attDmg3Int[0]) &&
                int.TryParse(rAttDmg3TextBox.Text, out attDmg3Int[1]) &&
                int.TryParse(lAirAttDmg3TextBox.Text, out airAttDmg3Int[0]) &&
                int.TryParse(rAirAttDmg3TextBox.Text, out airAttDmg3Int[1]) &&
                int.TryParse(lAtkPerShotTextBox.Text, out atkPerShotInt[0]) &&
                int.TryParse(rAtkPerShotTextBox.Text, out atkPerShotInt[1]) &&
                int.TryParse(lAirAtkShotTextBox.Text, out airAtkPerShotInt[0]) &&
                int.TryParse(rAirAtkShotTextBox.Text, out airAtkPerShotInt[1]) &&
                int.TryParse(lWpnUpgTextBox.Text, out wpnUpgradesInt[0]) &&
                int.TryParse(rWpnUpgTextBox.Text, out wpnUpgradesInt[1]) &&
                double.TryParse(lWpnCldnTextBox.Text, out wpnCooldownDbl[0]) &&
                double.TryParse(rWpnCldnTextBox.Text, out wpnCooldownDbl[1]) &&
                double.TryParse(lAirWpnCldnTextBox.Text, out airWpnCooldownDbl[0]) &&
                double.TryParse(rAirWpnCldnTextBox.Text, out airWpnCooldownDbl[1]))
            {
                // Assigns initial calculation values

                i = 0;
                a = 1;
                groundBox[0] = lGroundBox;
                groundBox[1] = rGroundBox;
                airBox[0] = lAirBox;
                airBox[1] = rAirBox;
                spellBox[0] = lSpellBox;
                spellBox[1] = rSpellBox;
                airSpellBox[0] = lAirSpellBox;
                airSpellBox[1] = rAirSpellBox;
                att1String[0] = lAtt1ComboBox.Text;
                att1String[1] = rAtt1ComboBox.Text;
                att2String[0] = lAtt2ComboBox.Text;
                att2String[1] = rAtt2ComboBox.Text;
                att3String[0] = lAtt3ComboBox.Text;
                att3String[1] = rAtt3ComboBox.Text;
                attDmg1String[0] = lAttDmg1ComboBox.Text;
                attDmg1String[1] = rAttDmg1ComboBox.Text;
                attDmg2String[0] = lAttDmg2ComboBox.Text;
                attDmg2String[1] = rAttDmg2ComboBox.Text;
                attDmg3String[0] = lAttDmg3ComboBox.Text;
                attDmg3String[1] = rAttDmg3ComboBox.Text;


                // Ensures ground and/or air is/are checked for each side

                // For loop applies operation to left and right side
                for (i = 0; i < 2; i++)
                {
                    if (groundBox[i].Checked == false && airBox[i].Checked == false)
                    {
                        groundBox[i].Checked = true;
                        MessageBox.Show("Ground and/or air must be selected for each unit.", "Missing Selection", MessageBoxButtons.OK);
                    }
                }

                // Calls calculation methods

                CalculateArmor();
                CalculateDmgPerShot();
                CalculateAirDmgPerShot();
                CalculateDmgPerSec();
                CalculateAirDmgPerSec();
                CalculateShotsToDestroy();
                CalculateAirShotsToDestroy();
                CalculateSecondsToDestroy();
                CalculateAirSecondsToDestroy();
            }
            else
            {
                foreach (Control C in this.Controls)
                {
                    if (C.Focused == true)
                    {
                        TextBox tBox = C as TextBox;
                        if (tBox.Text != "")
                        { MessageBox.Show("Please enter positive numerical values.", "Invalid Input", MessageBoxButtons.OK); }
                    }
                }
            }
        }

        //Replaces blank number inputs with default values
        public void tb_Clicked(object sender, EventArgs e)
        {
            if (lHpTextBox.Text == "")
            { lHpTextBox.Text = "0"; }
            if (rHpTextBox.Text == "")
            { rHpTextBox.Text = "0"; }
            if (lSpTextBox.Text == "")
            { lSpTextBox.Text = "0"; }
            if (rSpTextBox.Text == "")
            { rSpTextBox.Text = "0"; }
            if (lBseAmrTextBox.Text == "")
            { lBseAmrTextBox.Text = "0"; }
            if (rBseAmrTextBox.Text == "")
            { rBseAmrTextBox.Text = "0"; }
            if (lSpAmrTextBox.Text == "")
            { lSpAmrTextBox.Text = "0"; }
            if (rSpAmrTextBox.Text == "")
            { rSpAmrTextBox.Text = "0"; }
            if (lAmrUpgTextBox.Text == "")
            { lAmrUpgTextBox.Text = "0"; }
            if (rAmrUpgTextBox.Text == "")
            { rAmrUpgTextBox.Text = "0"; }
            if (lSpUpgTextBox.Text == "")
            { lSpUpgTextBox.Text = "0"; }
            if (rSpUpgTextBox.Text == "")
            { rSpUpgTextBox.Text = "0"; }
            if (lBseDmgTextBox.Text == "")
            { lBseDmgTextBox.Text = "0"; }
            if (rBseDmgTextBox.Text == "")
            { rBseDmgTextBox.Text = "0"; }
            if (lShieldDmgTextBox.Text == "")
            { lShieldDmgTextBox.Text = "0"; }
            if (rShieldDmgTextBox.Text == "")
            { rShieldDmgTextBox.Text = "0"; }
            if (lAirDmgTextBox.Text == "")
            { lAirDmgTextBox.Text = "0"; }
            if (rAirDmgTextBox.Text == "")
            { rAirDmgTextBox.Text = "0"; }
            if (lAirShieldDmgTextBox.Text == "")
            { lAirShieldDmgTextBox.Text = "0"; }
            if (rAirShieldDmgTextBox.Text == "")
            { rAirShieldDmgTextBox.Text = "0"; }
            if (lAttDmg1TextBox.Text == "")
            { lAttDmg1TextBox.Text = "0"; }
            if (lAttDmg2TextBox.Text == "")
            { lAttDmg2TextBox.Text = "0"; }
            if (lAttDmg3TextBox.Text == "")
            { lAttDmg3TextBox.Text = "0"; }
            if (rAttDmg1TextBox.Text == "")
            { rAttDmg1TextBox.Text = "0"; }
            if (rAttDmg2TextBox.Text == "")
            { rAttDmg2TextBox.Text = "0"; }
            if (rAttDmg3TextBox.Text == "")
            { rAttDmg3TextBox.Text = "0"; }
            if (lAirAttDmg1TextBox.Text == "")
            { lAirAttDmg1TextBox.Text = "0"; }
            if (lAirAttDmg2TextBox.Text == "")
            { lAirAttDmg2TextBox.Text = "0"; }
            if (lAirAttDmg3TextBox.Text == "")
            { lAirAttDmg3TextBox.Text = "0"; }
            if (rAirAttDmg1TextBox.Text == "")
            { rAirAttDmg1TextBox.Text = "0"; }
            if (rAirAttDmg2TextBox.Text == "")
            { rAirAttDmg2TextBox.Text = "0"; }
            if (rAirAttDmg3TextBox.Text == "")
            { rAirAttDmg3TextBox.Text = "0"; }
            if (lAtkPerShotTextBox.Text == "")
            { lAtkPerShotTextBox.Text = "1"; }
            if (rAtkPerShotTextBox.Text == "")
            { rAtkPerShotTextBox.Text = "1"; }
            if (lAirAtkShotTextBox.Text == "")
            { lAirAtkShotTextBox.Text = "1"; }
            if (rAirAtkShotTextBox.Text == "")
            { rAirAtkShotTextBox.Text = "1"; }
            if (lWpnUpgTextBox.Text == "")
            { lWpnUpgTextBox.Text = "0"; }
            if (rWpnUpgTextBox.Text == "")
            { rWpnUpgTextBox.Text = "0"; }
            if (lWpnCldnTextBox.Text == "")
            { lWpnCldnTextBox.Text = "0"; }
            if (rWpnCldnTextBox.Text == "")
            { rWpnCldnTextBox.Text = "0"; }
            if (lAirWpnCldnTextBox.Text == "")
            { lAirWpnCldnTextBox.Text = "0"; }
            if (rAirWpnCldnTextBox.Text == "")
            { rAirWpnCldnTextBox.Text = "0"; }
        }

        public void CalculateArmor()
        {
            // Calculates armor

            for (int i = 0; i < 2; i++)
            {
                if (att1String[i] == "Structure" || att2String[i] == "Structure" || att3String[i] == "Structure")
                { armorUpgradesInt[i] = 0; }
                armorInt[i] = baseArmorInt[i] + armorUpgradesInt[i];
                spAmrInt[i] = baseSpAmrInt[i] + spUpgradesInt[i];
            }

            // Displays armor stat
            lAmrStatLabel.Text = armorInt[0].ToString();
            rAmrStatLabel.Text = armorInt[1].ToString();
            lSpAmrStatLabel.Text = spAmrInt[0].ToString();
            rSpAmrStatLabel.Text = spAmrInt[1].ToString();

            // Resets array variable
            i = 0;
        }

        public void CalculateDmgPerShot()
        {
            int[] highestDmgInt = new int[2];
            int[] hiDmgSpInt = new int[2];
            int[] att1BonusInt = new int[2] { 0, 0 };
            int[] att2BonusInt = new int[2] { 0, 0 };
            int[] att3BonusInt = new int[2] { 0, 0 };

            for (i = 0; i < 2; i++)
            {
                // If/else if statement differentiates between left and right values when both sides are used for calculations
                if (a == i && i == 1)
                { a--; }
                else if (a == i && i == 0)
                { a++; }

                if (groundBox[a].Checked == true)
                {
                    // Determines highest possible damage before upgrades and armor deduction
                    if ((attDmg1String[i] == att1String[a] || attDmg1String[i] == att2String[a] || attDmg1String[i] == att3String[a]) && attDmg1String[i] != "")
                    { att1BonusInt[i] = baseDmgInt[i] + attDmg1Int[i]; }
                    if ((attDmg2String[i] == att1String[a] || attDmg2String[i] == att2String[a] || attDmg2String[i] == att3String[a]) && attDmg2String[i] != "")
                    { att2BonusInt[i] = baseDmgInt[i] + attDmg2Int[i]; }
                    if ((attDmg3String[i] == att1String[a] || attDmg3String[i] == att2String[a] || attDmg3String[i] == att3String[a]) && attDmg3String[i] != "")
                    { att3BonusInt[i] = baseDmgInt[i] + attDmg3Int[i]; }
                    highestDmgInt[i] = Math.Max(baseDmgInt[i], Math.Max(att1BonusInt[i], Math.Max(att2BonusInt[i], att3BonusInt[i])));
                    hiDmgSpInt[i] = highestDmgInt[i] + spDmgInt[i];

                    // Determines damage per shot

                    // Determines spellbox selection based on array number
                    if (spellBox[i].Checked == false)
                    {
                        int dmgUpgBonusInt;
                        double dmgUpgBonusDbl = highestDmgInt[i] * 0.1;

                        if (highestDmgInt[i] >= 10)
                        { dmgUpgBonusInt = Convert.ToInt32(Math.Round(dmgUpgBonusDbl, MidpointRounding.AwayFromZero)); }
                        else
                        { dmgUpgBonusInt = 1; }
                        if (dmgUpgBonusInt > 5)
                        { dmgUpgBonusInt = 5; }
                        if (att1String[i] == "Structure" || att2String[i] == "Structure" || att3String[i] == "Structure")
                        { dmgUpgBonusInt = 0; }

                        dpShotDbl[i] = ((highestDmgInt[i] + (dmgUpgBonusInt * wpnUpgradesInt[i])) * atkPerShotInt[i]) - (armorInt[a] * atkPerShotInt[i]);

                        if (dpShotDbl[i] <= 0)
                        {
                            if (baseDmgInt[i] > 0 && atkPerShotInt[i] > 0)
                            { dpShotDbl[i] = 0.5; }
                            else
                            { dpShotDbl[i] = 0; }
                        }
                        dpShotSpDbl[i] = ((hiDmgSpInt[i] + (dmgUpgBonusInt * wpnUpgradesInt[i])) * atkPerShotInt[i]) - (spAmrInt[a] * atkPerShotInt[i]);

                        if (dpShotSpDbl[i] <= 0)
                        {
                            if (spDmgInt[i] > 0 && atkPerShotInt[i] > 0)
                            { dpShotSpDbl[i] = 0.5; }
                            else
                            { dpShotSpDbl[i] = 0; }
                        }
                    }
                    else
                    {
                        dpShotDbl[i] = highestDmgInt[i] * atkPerShotInt[i];
                        dpShotSpDbl[i] = hiDmgSpInt[i] * atkPerShotInt[i];
                    }
                }
                else
                {
                    dpShotDbl[i] = 0;
                    dpShotSpDbl[i] = 0;
                }
            }

            // Displays damage per shot
            lDmgShotStatLabel.Text = dpShotDbl[0].ToString();
            rDmgShotStatLabel.Text = dpShotDbl[1].ToString();
            lSpDmgShotStatLabel.Text = dpShotSpDbl[0].ToString();
            rSpDmgShotStatLabel.Text = dpShotSpDbl[1].ToString();

            i = 0;
        }

        public void CalculateAirDmgPerShot()
        {
            int[] airHiDmgInt = new int[2];
            int[] airHiDmgSpInt = new int[2];
            int[] airAtt1BonusInt = new int[2] { 0, 0 };
            int[] airAtt2BonusInt = new int[2] { 0, 0 };
            int[] airAtt3BonusInt = new int[2] { 0, 0 };

            for (i = 0; i < 2; i++)
            {
                // If/else if statement differentiates between left and right values when both sides used for calculations
                if (a == i && i == 1)
                { a--; }
                else if (a == i && i == 0)
                { a++; }

                if (airBox[a].Checked == true)
                {
                    // Determines highest possible damage before upgrades and armor deduction
                    if ((attDmg1String[i] == att1String[a] || attDmg1String[i] == att2String[a] || attDmg1String[i] == att3String[a]) && attDmg1String[i] != "")
                    { airAtt1BonusInt[i] = baseDmgInt[i] + attDmg1Int[i]; }
                    if ((attDmg2String[i] == att1String[a] || attDmg2String[i] == att2String[a] || attDmg2String[i] == att3String[a]) && attDmg2String[i] != "")
                    { airAtt2BonusInt[i] = airDmgInt[i] + airAttDmg2Int[i]; }
                    if ((attDmg3String[i] == att1String[a] || attDmg3String[i] == att2String[a] || attDmg3String[i] == att3String[a]) && attDmg2String[i] != "")
                    { airAtt3BonusInt[i] = airDmgInt[i] + airAttDmg2Int[i]; }
                    airHiDmgInt[i] = Math.Max(airDmgInt[i], Math.Max(airAtt1BonusInt[i], Math.Max(airAtt2BonusInt[i], airAtt3BonusInt[i])));
                    airHiDmgSpInt[i] = airHiDmgInt[i] + airSpDmgInt[i];

                    // Determines damage per shot

                    // Determines spellbox selection based on array number
                    if (airSpellBox[i].Checked == false)
                    {
                        int dmgUpgBonusInt;
                        double dmgUpgBonusDbl = airHiDmgInt[i] * 0.1;

                        if (airHiDmgInt[i] >= 10)
                        { dmgUpgBonusInt = Convert.ToInt32(Math.Round(dmgUpgBonusDbl, MidpointRounding.AwayFromZero)); }
                        else
                        { dmgUpgBonusInt = 1; }

                        airDpShotDbl[i] = ((airHiDmgInt[i] + (dmgUpgBonusInt * wpnUpgradesInt[i])) * airAtkPerShotInt[i]) - (armorInt[a] * airAtkPerShotInt[i]);

                        if (airDpShotDbl[i] <= 0)
                        {
                            if (airDmgInt[i] > 0 && airAtkPerShotInt[i] > 0)
                            { airDpShotDbl[i] = 0.5; }
                            else
                            { airDpShotDbl[i] = 0; }
                        }
                        airDpShotSpDbl[i] = ((airHiDmgSpInt[i] + (dmgUpgBonusInt * wpnUpgradesInt[i])) * airAtkPerShotInt[i]) - (spAmrInt[a] * airAtkPerShotInt[i]);

                        if (airDpShotSpDbl[i] <= 0)
                        {
                            if (airSpDmgInt[i] > 0 && airAtkPerShotInt[i] > 0)
                            { airDpShotSpDbl[i] = 0.5; }
                            else
                            { airDpShotSpDbl[i] = 0; }
                        }
                    }
                    else
                    {
                        airDpShotDbl[i] = airHiDmgInt[i] * airAtkPerShotInt[i];
                        airDpShotSpDbl[i] = airHiDmgSpInt[i] * airAtkPerShotInt[i];
                    }
                }
                else
                {
                    airDpShotDbl[i] = 0;
                    airDpShotSpDbl[i] = 0;
                }
            }

            // Displays air damage per shot
            lAirDmgShotStatLabel.Text = airDpShotDbl[0].ToString();
            rAirDmgShotStatLabel.Text = airDpShotDbl[1].ToString();
            lAirSpDmgShotStatLabel.Text = airDpShotSpDbl[0].ToString();
            rAirSpDmgShotStatLabel.Text = airDpShotSpDbl[1].ToString();

            i = 0;
        }

        public void CalculateDmgPerSec()
        {
            // Calculates ground weapon damage per second, avoiding division by 0
            for (i = 0; i < 2; i++)
            {
                if (wpnCooldownDbl[i] != 0)
                {
                    dpSecondDbl[i] = dpShotDbl[i] / wpnCooldownDbl[i];
                    dpSecondSpDbl[i] = dpShotSpDbl[i] / wpnCooldownDbl[i];
                }
                else
                {
                    dpSecondDbl[i] = 0;
                    dpSecondSpDbl[i] = 0;
                }
            }

            // Displays damage per second
            lDmgSecStatLabel.Text = dpSecondDbl[0].ToString();
            rDmgSecStatLabel.Text = dpSecondDbl[1].ToString();
            lSpDmgSecStatLabel.Text = dpSecondSpDbl[0].ToString();
            rSpDmgSecStatLabel.Text = dpSecondSpDbl[1].ToString();

            i = 0;
        }

        public void CalculateAirDmgPerSec()
        {
            // Calculates air weapon damage per second, avoiding division by 0
            for (i = 0; i < 2; i++)
            {
                if (airWpnCooldownDbl[i] != 0)
                {
                    airDpSecondDbl[i] = airDpShotDbl[i] / airWpnCooldownDbl[i];
                    airDpSecondSpDbl[i] = airDpShotSpDbl[i] / airWpnCooldownDbl[i];
                }
                else
                {
                    airDpSecondDbl[i] = 0;
                    airDpSecondSpDbl[i] = 0;
                }
            }

            // Displays damage per second
            lAirDmgSecStatLabel.Text = airDpSecondDbl[0].ToString();
            rAirDmgSecStatLabel.Text = airDpSecondDbl[1].ToString();
            lAirSpDmgSecStatLabel.Text = airDpSecondSpDbl[0].ToString();
            rAirSpDmgSecStatLabel.Text = airDpSecondSpDbl[1].ToString();

            i = 0;
        }

        public void CalculateShotsToDestroy()
        {
            // Calculates ground weapon shots to destroy, avoiding division by 0
            for (i = 0; i < 2; i++)
            {
                if (a == i && i == 1)
                { a--; }
                else if (a == i && i == 0)
                { a++; }

                if (spellBox[i].Checked == false)
                { totalSpDmgDbl[i] = spDmgInt[i] - spAmrInt[a]; }
                else
                { totalSpDmgDbl[i] = spDmgInt[i]; }

                if (dpShotDbl[i] > 0 && dpShotSpDbl[i] > 0)
                {
                    for (spRemainingDbl[i] = spInt[a]; spRemainingDbl[i] >= (spDmgInt[i] - spAmrInt[a]); spRemainingDbl[i] = spRemainingDbl[i] - dpShotSpDbl[i])
                    { shotCounterInt[i]++; }

                    if (spRemainingDbl[i] > 0)
                    {
                        spRemainingDbl[i] = dpShotDbl[i] * -1;
                        shotCounterInt[i]++;
                    }

                    for (hpRemainingDbl[i] = hpInt[a] + spRemainingDbl[i] + armorInt[a]; hpRemainingDbl[i] > 0; hpRemainingDbl[i] = hpRemainingDbl[i] - dpShotDbl[i])
                    { shotCounterInt[i]++; }

                    shotsKillInt[i] = shotCounterInt[i];
                    overkillDbl[i] = hpRemainingDbl[i] * -1;
                }
                else
                {
                    shotsKillInt[i] = 0;
                    overkillDbl[i] = 0;
                }
            }

            // Displays shots to destroy
            lShotKillStatLabel.Text = shotsKillInt[0].ToString();
            rShotKillStatLabel.Text = shotsKillInt[1].ToString();
            
            // Displays overkill
            lOverStatLabel.Text = overkillDbl[0].ToString();
            rOverStatLabel.Text = overkillDbl[1].ToString();

            shotCounterInt[0] = 0;
            shotCounterInt[1] = 0;

            i = 0;
        }

        public void CalculateAirShotsToDestroy()
        {
            // Calculates air weapon shots to destroy, avoiding division by 0
            for (i = 0; i < 2; i++)
            {
                if (a == i && i == 1)
                { a--; }
                else if (a == i && i == 0)
                { a++; }

                if (spellBox[i].Checked == false)
                { totalSpDmgDbl[i] = airSpDmgInt[i] - spAmrInt[a]; }
                else
                { totalSpDmgDbl[i] = airSpDmgInt[i]; }

                if (airDpShotDbl[i] > 0 && airDpShotSpDbl[i] > 0)
                {
                    for (spRemainingDbl[i] = spInt[a]; spRemainingDbl[i] >= (airSpDmgInt[i] - spAmrInt[a]); spRemainingDbl[i] = spRemainingDbl[i] - airDpShotSpDbl[i])
                    { shotCounterInt[i]++; }

                    if (spRemainingDbl[i] > 0)
                    {
                        spRemainingDbl[i] = airDpShotDbl[i] * -1;
                        shotCounterInt[i]++;
                    }

                    for (hpRemainingDbl[i] = hpInt[a] + spRemainingDbl[i]; hpRemainingDbl[i] > 0; hpRemainingDbl[i] = hpRemainingDbl[i] - airDpShotDbl[i])
                    { shotCounterInt[i]++; }

                    airShotsKillInt[i] = shotCounterInt[i];
                    airOverkillDbl[i] = hpRemainingDbl[i] * -1;
                }
                else
                {
                    airShotsKillInt[i] = 0;
                    airOverkillDbl[i] = 0;
                }
            }

            // Displays shots to destroy
            lAirShotKillStatLabel.Text = airShotsKillInt[0].ToString();
            rAirShotKillStatLabel.Text = airShotsKillInt[1].ToString();

            // Displays overkill
            lAirOverStatLabel.Text = airOverkillDbl[0].ToString();
            rAirOverStatLabel.Text = airOverkillDbl[1].ToString();

            shotCounterInt[0] = 0;
            shotCounterInt[1] = 0;

            i = 0;
        }

        public void CalculateSecondsToDestroy()
        {
            // Calculates ground weapon seconds to destroy
            for (i = 0; i < 2; i++)
            { secKillDbl[i] = shotsKillInt[i] * wpnCooldownDbl[i]; }

            // Displays seconds to destroy
            lSecKillStatLabel.Text = secKillDbl[0].ToString();
            rSecKillStatLabel.Text = secKillDbl[1].ToString();

            i = 0;
        }

        public void CalculateAirSecondsToDestroy()
        {
            // Calculates air weapon seconds to destroy
            for (i = 0; i < 2; i++)
            { airSecKillDbl[i] = airShotsKillInt[i] * airWpnCooldownDbl[i]; }

            // Displays seconds to destroy
            lAirSecKillStatLabel.Text = airSecKillDbl[0].ToString();
            rAirSecKillStatLabel.Text = airSecKillDbl[1].ToString();

            i = 0;
        }

        private void lMaxUpgBtn_Click(object sender, EventArgs e)
        {
            tb_Clicked(sender, e);
            lAmrUpgTextBox.Text = "3";
            lSpUpgTextBox.Text = "3";
            lWpnUpgTextBox.Text = "3";
        }

        private void lClrUpgBtn_Click(object sender, EventArgs e)
        {
            tb_Clicked(sender, e);
            lAmrUpgTextBox.Text = "0";
            lSpUpgTextBox.Text = "0";
            lWpnUpgTextBox.Text = "0";
        }

        private void rMaxUpgBtn_Click(object sender, EventArgs e)
        {
            tb_Clicked(sender, e);
            rAmrUpgTextBox.Text = "3";
            rSpUpgTextBox.Text = "3";
            rWpnUpgTextBox.Text = "3";
        }

        private void rClrUpgBtn_Click(object sender, EventArgs e)
        {
            tb_Clicked(sender, e);
            rAmrUpgTextBox.Text = "0";
            rSpAmrTextBox.Text = "0";
            rWpnUpgTextBox.Text = "0";
        }

        private void mainForm_Load(object sender, EventArgs e)
        {        }
    }
}
