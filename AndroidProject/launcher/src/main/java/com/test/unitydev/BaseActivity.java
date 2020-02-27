package com.test.unitydev;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.FrameLayout;

public class BaseActivity extends AppCompatActivity {

    private Intent unityIntent;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_base);
    }

    public void loadUnityActivity (View v)
    {
        unityIntent = new Intent(this, com.unity3d.player.UnityPlayerActivity.class);
        unityIntent.setFlags(Intent.FLAG_ACTIVITY_REORDER_TO_FRONT);
        startActivity(unityIntent);
    }

    public void btnUnloadUnity(View v) {
        Intent intent = new Intent(this, BaseActivity.class);
        intent.setFlags(Intent.FLAG_ACTIVITY_REORDER_TO_FRONT);
        intent.putExtra("doQuit", true);
        startActivity(intent);
    }
}