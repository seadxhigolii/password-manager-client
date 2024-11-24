﻿namespace password_manager_client.Helpers
{
    public class UIManager
    {
        private readonly Control _mainPanel;
        private readonly Label _itemInformationLabel;
        private readonly GroupBox _lastUpdatedGroupBox;
        private readonly Label _passwordHistoryLabel;
        private readonly Label _passwordHistoryValue;
        private readonly Button _saveButton;
        private readonly Button _editButton;
        private readonly Button _cancelButton;
        private readonly PictureBox _saveIcon;
        private readonly PictureBox _editIcon;
        private readonly Button _duplicateButton;
        private readonly PictureBox _duplicateIcon;
        private readonly GroupBox _mainGroup;

        public UIManager(
            Control mainPanel,
            Label itemInformationLabel,
            GroupBox lastUpdatedGroupBox,
            Label passwordHistoryLabel,
            Label passwordHistoryValue,
            Button saveButton,
            Button editButton,
            Button cancelButton,
            PictureBox saveIcon,
            PictureBox editIcon,
            Button duplicateButton,
            PictureBox duplicateIcon,
            GroupBox mainGroup
        )
        {
            _mainPanel = mainPanel;
            _itemInformationLabel = itemInformationLabel;
            _lastUpdatedGroupBox = lastUpdatedGroupBox;
            _passwordHistoryLabel = passwordHistoryLabel;
            _passwordHistoryValue = passwordHistoryValue;
            _saveButton = saveButton;
            _editButton = editButton;
            _cancelButton = cancelButton;
            _saveIcon = saveIcon;
            _editIcon = editIcon;
            _duplicateButton = duplicateButton;
            _duplicateIcon = duplicateIcon;
            _mainGroup = mainGroup;
        }

        public void ConfigureForViewVault(bool hasPasswordHistory, string passwordHistoryValueText)
        {
            _itemInformationLabel.Visible = true;
            _itemInformationLabel.Text = "ITEM INFORMATION";
            _lastUpdatedGroupBox.Visible = true;

            _passwordHistoryLabel.Visible = hasPasswordHistory;
            _passwordHistoryValue.Visible = hasPasswordHistory;
            _passwordHistoryValue.Text = passwordHistoryValueText;

            ConfigureButtons(
                showSave: false,
                showEdit: true,
                showDuplicate: false
            );

            _mainGroup.Visible = false;
        }

        public void ConfigureForCreateVault()
        {
            _itemInformationLabel.Visible = true;
            _itemInformationLabel.Text = "ADD ITEM";
            _lastUpdatedGroupBox.Visible = false;

            ConfigureButtons(
                showSave: true,
                showEdit: false,
                showDuplicate: false
            );

            _mainGroup.Visible = false;
        }

        public void ConfigureForEditVault()
        {

            ConfigureButtons(
                showSave: true,
                showEdit: false,
                showDuplicate: false
            );

            _mainGroup.Visible = false;
        }

        public void ResetToMainView()
        {
            foreach (Control control in _mainPanel.Controls.Cast<Control>().ToList())
            {
                if (control is UserControl)
                {
                    _mainPanel.Controls.Remove(control);
                }
            }

            _itemInformationLabel.Visible = false;
            _lastUpdatedGroupBox.Visible = false;
            _mainGroup.Visible = true;

            ConfigureButtons(
                showSave: false,
                showEdit: false,
                showDuplicate: false
            );
        }

        public void ClearMainPanel(UserControl activeControl)
        {
            _mainPanel.Controls.Remove(activeControl);
        }

        public UserControl SetActiveUserControl(ref UserControl activeControl, UserControl userControlToSet)
        {
            activeControl = userControlToSet;
            return activeControl;
        }

        public void LoadUserControl(UserControl userControl, int topPosition)
        {
            _mainPanel.Controls.Add(userControl);

            userControl.Dock = DockStyle.None;
            userControl.Anchor = AnchorStyles.None;

            userControl.Left = (_mainPanel.ClientSize.Width - userControl.Width) / 2;
            userControl.Top = topPosition;
            userControl.BringToFront();
        }

        private void ConfigureButtons(bool showSave, bool showEdit, bool showDuplicate)
        {
            _saveButton.Visible = showSave;
            _saveIcon.Visible = showSave;

            _editButton.Visible = showEdit;
            _editIcon.Visible = showEdit;

            _duplicateButton.Visible = showDuplicate;
            _duplicateIcon.Visible = showDuplicate;

            _cancelButton.Location = _duplicateButton.Location;

            if (showSave)
            {
                _saveButton.Location = _editButton.Location;
                _saveIcon.Location = _editIcon.Location;
            }
        }
    }
}