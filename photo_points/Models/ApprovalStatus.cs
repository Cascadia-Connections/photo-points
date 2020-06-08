namespace photo_points.Models
{
    public enum ApprovalStatus
    {
        //Pending is the default. So when a new capture is created it will be waiting for admin approval.

        Pending,
        Approve,
        Reject
    }
}