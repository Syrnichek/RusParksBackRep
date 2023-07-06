namespace RusParksBack.Interfaces
{
    public interface IAdminManageService
    {
        public void ReviewDelete(int reviewid);

        public void ParkAdd(string parkname, string parkcity, string parkmetro, IFormFile[] mainimages,
            string[] imagepath, string maintext, string enterinfotext, int[] typeid);

        public void NewsAdd(string newstitle, string newsimage, IFormFile[] newsImage, string newstext);
    }
}