namespace RusParksBack.Interfaces
{
    public interface IAdminManageService
    {
        public void ReviewDelete(int reviewid);

        public void ParkAdd(string parkname, string parkcity, string parkmetro, string[] mainimages, string maintext, string enterinfotext);

        public void NewsAdd();
    }
}