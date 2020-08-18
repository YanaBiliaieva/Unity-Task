using UnityEngine;

public class CameraHelper
{

    public static readonly float
        clampMinX,
        clampMaxX,
        clampMinY,
        clampMaxY,
        bottomOffsetY,
        topOffsetY,
        leftOffsetX,
        rightOffsetX;

    private const int StageStepDivider = 6;

    static CameraHelper()
    {
        var distance = Mathf.Abs((0 - Camera.main.transform.position.z));
        Vector3 stageDimensions = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector2 bounds = new Vector2(stageDimensions.x, stageDimensions.y);
        clampMinX = bounds.x;
        clampMaxX = -bounds.x;
        clampMinY = bounds.y;
        clampMaxY = -bounds.y;
        bottomOffsetY = clampMinY + Mathf.Abs(clampMinY - clampMaxY) / StageStepDivider;
        topOffsetY = clampMaxY - Mathf.Abs(clampMinY - clampMaxY) / StageStepDivider;
        leftOffsetX = clampMinX + Mathf.Abs(clampMinX - clampMaxX) / StageStepDivider;
        rightOffsetX = clampMaxX - Mathf.Abs(clampMinX - clampMinX) / StageStepDivider;
    }
}